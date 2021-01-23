    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            MessageBox.Show("Cancelled");
            progressBar1.Value = 0;
        }
        else
        {
            MessageBox.Show("Done");
            progressBar1.Value = 0;                
        }
    }
