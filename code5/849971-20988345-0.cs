            public void myFunc()
            {
                lbl_status.Text = "Loading ... Please Wait";
                BackgroundWorker bw = new BackgroundWorker();
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.RunWorkerAsync();
               
            }
    
            void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                // Some Database Works
                lbl_status.Text = "Done";
            }
