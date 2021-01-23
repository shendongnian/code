    Thread backgroundThread = new Thread(BackgroundWork);
    DateTime nextInterval = DateTime.Now;
    public void BackgroundWork()
    {
        if(DateTime.Now > nextInterval){
            DoWork();
            nextInterval = nextInterval.Add(new TimeSpan(0,0,0,10)); // 10 seconds
        }
        Thread.Sleep(100);
    }
