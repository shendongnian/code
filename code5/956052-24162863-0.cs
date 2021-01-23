    public void StartProcessing()
    {
        var thread = new Thread(() => this.DoProcessing);
        thread.Start();
    }
