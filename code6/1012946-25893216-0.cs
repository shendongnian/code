    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.WorkerReportsProgress = true;
                bw.RunWorkerAsync();
    
                Console.ReadKey();
            }
    
            static void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                Console.WriteLine("Percentage is:{0}%", e.ProgressPercentage);
            }
    
            static void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                var self = (sender as BackgroundWorker);
                self.ReportProgress(10);
                Thread.Sleep(1000);
                self.ReportProgress(20);
                Thread.Sleep(1000);
                self.ReportProgress(30);
            }
    
        }
    }
