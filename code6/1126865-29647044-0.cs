                if (backgroundWorker1.IsBusy != true)
            {
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                
                transferFileType = 'R';
                connecting = true;
                statusBarLbl.Text = "Processing.....Transferring Report Files to PC ";
                progressStatusLbl.Text = "Retrieving Device Id and Info";
                // Start the asynchronous operation
                backgroundWorker1.RunWorkerAsync();
            }
