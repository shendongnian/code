    public void InitTest()
    {
        bool succeeded = false;
        Controller target = new Controller();
        target.FinishedCommand += delegate(bool success)
        {
            succeeded = success;
            eventRaised.Set();
        };
        ManualResetEvent eventRaised = new ManualResetEvent(false);
        target.Init();
        eventRaised.WaitOne();
        Assert.IsTrue(succeeded);
    }
