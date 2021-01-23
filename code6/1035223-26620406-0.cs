    public string DoSomethingQuick()
    {
        var backgroundWorker = new BackgroundWorker();
        backgroundWorker.DoWork += delegate(object s, DoWorkEventArgs args)
        {
             DoSomethingThatTakes10Minutes();
        };
        backgroundWorker.RunWorkerAsync();
        return "Process Started"; 
    }
