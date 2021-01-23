            BackgroundWorker NewWorker = new BackgroundWorker();
            NewWorker.DoWork += new DoWorkEventHandler(NewWorker_DoWork);
            NewWorker.ProgressChanged += new ProgressChangedEventHandler(NewWorker_ProgressChanged);
            NewWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(NewWorker_RunWorkerCompleted);
            NewWorker.WorkerReportsProgress = true;
            
            NewWorker.RunWorkerAsync();
        }
        void NewWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> ReturnResults = new List<string>();
            BackgroundWorker worker = sender as BackgroundWorker;
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select StatusCode from Win32_PingStatus where address = 'Metabox-PC'");
                    ManagementObjectCollection objCollection = searcher.Get();
                    foreach (ManagementObject Results in objCollection)
                    {
                        ReturnResults.Add(Results["StatusCode"].ToString());
                    }
                    e.Result = ReturnResults;
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(1);
        }
        private void NewWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                txtPingable.text = e.Result;
        }
