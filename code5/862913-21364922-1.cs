        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int p = 0;
            int high = 10000;
            do
            {
                for (int i = 0; i < high; i++)
                {
                    if (i%10 == 0 && backgroundWorker1.CancellationPending)
                        break;
                    if (i%100 == 0) // for performance purposes
                    {
                        p = (int) ((float) i/high*100);
                        backgroundWorker1.ReportProgress(p, i);
                    }
                }
            } while (!backgroundWorker1.CancellationPending);          
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.UserState!=null)
            label1.Text = e.UserState.ToString();
            progressBar1.Value = e.ProgressPercentage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
