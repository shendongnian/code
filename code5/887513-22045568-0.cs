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
    using System.IO.Ports;
    using System.Threading;
    using System.Windows.Threading;
    using System.Data.SQLite;
    namespace Datalogging
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public class ThreadExample
        {
            public static void ThreadJob()
            {
                string dBConnectionString = @"Data Source = C:\Users\johnmark\Documents\Visual Studio 2012\Projects\SerialTrial\SerialTrial\bin\Debug\employee.sqlite;";
                SQLiteConnection sqliteCon = new SQLiteConnection(dBConnectionString);
                //open connection to database
                try
                {
                    sqliteCon.Open();
                    SQLiteCommand createCommand = new SQLiteCommand("Select empID from EmployeeList", sqliteCon);
                    SQLiteDataReader reader;
                    reader = createCommand.ExecuteReader();
                    //richtextbox2.Document.Blocks.Clear();
                    while (reader.Read())
                    {
                        string Text = (String.Format("{0}", Object.Equals(definition.buffering, reader.GetValue(0))));
                        if (Convert.ToBoolean(Text))
                        {
                            Console.WriteLine(Text);
                            //richtextbox2.Document.Blocks.Add(new Paragraph(new Run(Text)));
                        }
                    }
                    sqliteCon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public partial class MainWindow : Window
        {
    
            //string received_data;
            //Thread readThread = new Thread(Read);
            FlowDocument mcFlowDoc = new FlowDocument();
            Paragraph para = new Paragraph();
            SerialPort serial = new SerialPort();
            public MainWindow()
            {
                InitializeComponent();
                combobox1.Items.Insert(0, "Select Port");
                combobox1.SelectedIndex = 0;
                string[] ports = null;
                ports = SerialPort.GetPortNames();
                // Display each port name to the console. 
                int c = ports.Count();
                for (int i = 1; i <= c; i++)
                {
                    if (!combobox1.Items.Contains(ports[i - 1]))
                    {
                        combobox1.Items.Add(ports[i - 1]);
                    }
                }
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if ((string)button2.Content == "Connect")
                    {
                        string myItem = combobox1.SelectedItem.ToString();
                        if (myItem == "Select Port")
                        {
                            MessageBox.Show("Select Port");
                        }
                        else
                        {
                            serial.PortName = myItem;
                            serial.Open();
                            button2.Content = "Disconnect";
                            textbox2.Text = "Serial Port Opened";
                            serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived);
                        }
                    }
                    else
                    {
                        serial.Close();
                        button2.Content = "Connect";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
    
            #region Receiving
            public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                int bytes = serial.BytesToRead;
                byte[] buffer = new byte[bytes];
                serial.Read(buffer, 0, bytes);
                foreach (var item in buffer)
                {
                    Console.Write(item.ToString());
                }
                definition.buffering = BitConverter.ToInt64(buffer, 0);
                Console.WriteLine();
                Console.WriteLine(definition.buffering);
                Console.WriteLine();
                Thread thread = new Thread(new ThreadStart(ThreadExample.ThreadJob));
                thread.Start();
            }
            #endregion
        }
    }
