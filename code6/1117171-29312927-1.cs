    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var bgw = (BackgroundWorker)sender;
        bgw.ReportProgress(33, "MethodOne Process Has Begun.....");
        MethodOne();
        bgw.ReportProgress(66, "MethodTwo Process Has Begun.....");
        MethodTwo();
        bgw.ReportProgress(100, "All Processes Finished.");
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
        panel1.Controls.Add("MethodTwo Process Has Begun....."");
    }
