        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            (some-loop-construct) {
                if (backgroundWorker1.CancellationPending) {
                   e.Cancel = true;    // Important!
                   return;
                }
                // etc...
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                // Something bad happened
            }
            else if (e.Cancelled) {
                // It actually got cancelled
            }
            else {
                // It actually completed
            }
        }
