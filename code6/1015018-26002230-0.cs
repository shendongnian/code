        private void ProcessEnded(object sender, EventArgs e)
        {
            var process = sender as Process;
            if (process != null)
            {
                var test = process.ExitCode;
            }
        }
