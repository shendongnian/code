        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            const int maxIterations = 10000;
            var progressLimit = 100;
            var staging = new List<int>();
            for (int i = 0; i < maxIterations; i++)
            {
                staging.Add(i);
                if (staging.Count % progressLimit == 0)
                {
                    // Only send a COPY of the staging list because we 
                    // may continue to modify staging inside this loop.
                    // There are many ways to do this.  Below is just one way.
                    backgroundWorker1.ReportProgress(staging.Count, staging.ToArray());
                    staging.Clear();
                }
            }
            // Flush last bit in staging.
            if (staging.Count > 0)
            {
                // We are done with staging here so we can pass it as is.
                backgroundWorker1.ReportProgress(staging.Count, staging);
            }
        }
        // The ProgressChanged event is triggered in the background thread
        // but actually executes in the UI thread.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0) return;
            // We don't care if an array or a list was passed.
            var updatedIndices = e.UserState as IEnumerable<int>;
            var sb = new StringBuilder();
            foreach (var index in updatedIndices)
            {
                sb.Append(index.ToString() + Environment.NewLine);
            }
            textBoxOutput.Text += sb.ToString();
        }
