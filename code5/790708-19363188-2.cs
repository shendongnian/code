    private void click(object sender, RoutedEventArgs e)
    {
        if (progressDialog == null) progressDialog = new Progress();
        progressDialog.Show();
    }
    namespace BackGroundWorkerShowDialog
    {
        /// <summary>
        /// Interaction logic for Progress.xaml
        /// </summary>
        public partial class Progress : Window
        {
            BackgroundWorker bwLoadCSV = new BackgroundWorker();
            public Progress()
            {
                InitializeComponent();
                //assign events to backgroundworkers
                bwLoadCSV.WorkerReportsProgress = true;
                bwLoadCSV.WorkerSupportsCancellation = true;
                bwLoadCSV.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                bwLoadCSV.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
                bwLoadCSV.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
                if (bwLoadCSV.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    bwLoadCSV.RunWorkerAsync();
                }
    
            }
    
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                for (int i = 1; i <= 10; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        // Perform a time consuming operation and report progress.
                        System.Threading.Thread.Sleep(500);
                        worker.ReportProgress(i * 10);
                    }
                }
            }
    
            private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
    
                if (e.Cancelled == true)
                {
                    //resultLabel.Text = "Canceled!";
                }
                else if (e.Error != null)
                {
                    //resultLabel.Text = "Error: " + e.Error.Message;
                }
                else
                {
                    //resultLabel.Text = "Done: " + e.Error.Message;
                }
                this.Close();
            }
    
            private void backgroundWorker1_ProgressChanged(object sender,
                ProgressChangedEventArgs e)
            {
                this.tbProgress.Text = e.ProgressPercentage.ToString();
            }
        }
    
    }
