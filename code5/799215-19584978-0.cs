    public static void CalculateAttributions(BackgroundWorker worker, string _filename, ComboBox cmb, OpenFileDialog open)
            {
                worker = new BackgroundWorker { WorkerReportsProgress = true };
        worker.DoWork +=     new DoWorkEventHandler(worker_DoWork);
    worker.ProgressChanged +=         new ProgressChangedEventHandler(worker_ProgressChanged);
    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
    
    if (worker.IsBusy != true)
        {
            worker.RunWorkerAsync();
        }
        
    }
    
     private void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
    
                while (wave.Position != length)
                {
                   ...Process..
                    worker.ReportProgress((100 * (int)(length / wave.Position)) / (int)(length / mainBuffer.Length));
                }
            }
    
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar1.Value = Math.Min(e.ProgressPercentage, 100);
            }
    
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                //done
            }
