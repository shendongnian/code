    public void GetUrls()
    {
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
        int i = 0;
        timer.Tick += (s, e) =>
           {
               Urls.Add(new Url { link = i.ToString() });
               ++i;
               if (i == 5)
                 timer.Stop();
           };
        timer.Start();
    }
