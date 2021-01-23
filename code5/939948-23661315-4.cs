    ManualResetEvent Copy1Done = new ManualResetEvent(false);
    ManualResetEvent Copy2Done = new ManualResetEvent(false);
    Timer t1 = new Timer((s) =>
        {
            Class myClass0 = new Class();
            myClass0.CopyFiles(15, cts0.Token);
            Copy1Done.Set();
        }, null, TimeSpan.FromMinutes(15), TimeSpan.FromMilliseconds(-1));
    Timer t1 = new Timer((s) =>
        {
            Class myClass1 = new Class();
            myClass0.CopyFiles(30, cts1.Token);
            Copy2Done.Set();
        }, null, TimeSpan.FromMinutes(30), TimeSpan.FromMilliseconds(-1));
