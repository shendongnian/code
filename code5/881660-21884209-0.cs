        private void ReportProgress(ProgressReportInfo info)
        {
            // or better BeginInvoke
            Invoke(() =>
            {
                progressBar1.Value = info.Percentage;
                label1.Text = info.Status;
            });
        }
