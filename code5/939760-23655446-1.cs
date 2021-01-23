    private BackgroundWorker _worker = new BackgroundWorker();
    public Controller()
    {
        _worker.WorkerReportsProgress = true;
        _worker.DoWork += DoWork;
        _worker.ProgressChanged += ProgressChanged;
        _worker.RunWorkerCompleted += RunWorkerCompleted;
    }
    private void ControllerMethod()
    {
        var tokens = requester.GetResponses(addresses);
        _worker.RunWorkerAsync(tokens);
    }
    private void DoWork(object sender, DoWorkEventArgs e)
    {
        var tokens = e.Argument as List<string>;
        if (tokens == null) { return; }
        // declare the result variable here
        // I don't know what it is; but you'll concatenate
        // the results below where I show the response
        var completedTokens = new List<string>();
        while (completedTokens.Count < tokens.Count)
        {
            foreach (var tokenId in tokens)
            {
                var status = GetProgStatus(tokenId);
                if (status == "Complete")
                {
                    completedTokens.Add(tokenId);
                    // maybe call
                    // worker.ReportProgress(completedTokens.Count, "some status text");
                    var response = GetResults(tokenId);
                    // if response is a list or array, just use LINQ to
                    // add the response to an overall result that is declared
                    // outside of the while loop
                }
                else
                {
                    // check other statuses here and maybe call
                    // worker.ReportProgress(completedTokens.Count, "some status text");
                }
            }
            // sleep for some duration and check again
            Thread.Sleep(1000);
        }
        e.Result = result;
    }
    private void ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // here you can use that real percentage complete value to set
        // a progress bar; or maybe SignalR to send a progress if you're
        // inside a web application
        // this.progressBar1.Value = e.ProgressPercentage;
        // and now here you can even grab that textual progress
        var progress = e.UserState as string;
    }
    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // here you can now get at that result
        var result = e.Result as {SomeType};
    }
