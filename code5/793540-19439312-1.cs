    private void btnReadAll_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.DoWork += bw_DoWork;
                bw.ProgressChanged += bw_ProgressChanged);
                bw.RunWorkerCompleted +=bw_RunWorkerCompleted;
                // Start the ReadAll parameters thread
                btnReadAll.Text = "Cancel Read";
                btnWriteAll.Enabled = false;
                bw.RunWorkerAsync("R");
            }
            else if (bw.WorkerSupportsCancellation == true)
            {
                // Cancel the ReadAll parameters thread
                bw.CancelAsync();
            }
            bw.DoWork -= bw_DoWork;
            bw.ProgressChanged -= bw_ProgressChanged;
            bw.RunWorkerCompleted -= bw_RunWorkerCompleted;
        }
