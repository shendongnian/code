        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var workItem in work)
            {
                workItem.Perform();
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
            }
        }
