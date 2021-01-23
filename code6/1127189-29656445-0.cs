    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        var bg = (BackgroundWorker)sender;
        var myCollection = new List<SomeClass>();
        while(/* somehow test whether there's more data to get */)
        {
            myCollection.AddRange(GetSomeMoreReportData());
            bg.ReportProgress(0);  // or pass a valid "percentage" if you can calculate it
        }
        // Don't access the UI from a background thread.
        // The safest thing you can do is pass the final data to the RunWorkerCompleted event
        e.Result = myCollection;
    }
    void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // You're back in the UI thread, update your ProgressBar
    }
    void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        List<SomeClass> result = (List<SomeClass>)e.Result;
        // You're back in the UI thread, update your UI with the data
    }
