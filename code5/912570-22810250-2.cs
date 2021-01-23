    private void TestButton_Click(object sender, EventArgs e)
    {
        TestButton.Enabled = false;
        var uiThreadScheduler = TaskScheduler.FromCurrentSynchronizationContext();
     
        var backgroundTask = new Task(() =>
        {
            Thread.Sleep(5000);
        });
     
        var uiTask = backgroundTask.ContinueWith(t =>
        {
            TestButton.Enabled = true;
        }, uiThreadScheduler);
     
        backgroundTask.Start();
    }
