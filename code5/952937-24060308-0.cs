    bw.ProgressChanged += (sender, eventArgs) =>
                {
                    Console.WriteLine(eventArgs.UserState);
                };
    private static void BwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
            {
                var bw = sender as BackgroundWorker;
                bw.ReportProgress(0, "My State is updated");
            }
