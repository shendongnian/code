    public void InitTest()
    {
        Controller target = new Controller();
        target.FinishedCommand += delegate(bool success)
        {
            Assert.AreEqual(true, success);
            eventRaised.Set();
        };
        ManualResetEvent eventRaised = new ManualResetEvent(false);
        target.Init();
        eventRaised.WaitOne();
    }
