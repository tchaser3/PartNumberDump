/* Title:           Part Number Dump
 * Date:            3-25-17
 * Author:          Terry Holmes
 * 
 * Description:     This will show all of the part numbers */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewEventLogDLL;
using PartNumberDLL;

namespace PartNumberDump
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //setting up the classes
        WPFMessagesClass TheMessagesClass = new WPFMessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PartNumberClass ThePartNumberClass = new PartNumberClass();

        //setting up the data
        PartNumbersDataSet ThePartNumbersDataSet;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this will active during the load
            try
            {
                ThePartNumbersDataSet = ThePartNumberClass.GetPartNumbersInfo();

                dgrParts.ItemsSource = ThePartNumbersDataSet.partnumbers;
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Dump Main Window Window Loaded " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //this will close the application
            TheMessagesClass.CloseTheProgram();
        }
    }
}
