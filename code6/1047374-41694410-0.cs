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
    
    using System.ComponentModel;
    using System.Data;
    
    namespace MouseClick
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
           
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public BackgroundWorker worker = new BackgroundWorker();
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                //e.Handled = true; // Din't do anything 
                worker = new BackgroundWorker(); //stopped the dowork being executed multiple times when button pressed again in the same session
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
    
            }
    
            void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                
    
                int tot = 1;
                
                MessageBox.Show(tot.ToString()); //if this message box appears multiple times, it means the dowork is executing multiple times
    
                DataTable dt = new DataTable();
    
                dt.Columns.Add("Running Number");
    
                for (int i = 0; i <= 100; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        //http://stackoverflow.com/questions/8300799/cancel-background-worker-exception-in-e-result
                        //  e.Cancel = true; //This does the trick
                        e.Result = 100;
                        return;
                    }
                    worker.ReportProgress(i);
                    System.Threading.Thread.Sleep(1);
                    dt.Rows.Add(i);
                }
                e.Result = dt;
            }
    
            #region "worker_ProgressChanged"
            void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
               
            }
            #endregion
    
            #region "worker_RunWorkerCompleted"
            void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                myGrid.ItemsSource = ((DataTable)e.Result).DefaultView;
                worker.Dispose();
                
            }
            #endregion
    
        }
    }
