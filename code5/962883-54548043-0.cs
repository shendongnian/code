    DateTime runTime = new DateTime();
    double waitSeconds = (runTime - DateTime.Now).TotalSeconds;
    Task.Factory.StartNew(() =>
    {
        Thread.Sleep(TimeSpan.FromSeconds(waitSeconds));
        YourMethod();
    });
