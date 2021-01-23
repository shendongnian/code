    private volatile int i;
    private object iLock = new object();
    ...
    while (i < lst.Count)
    {
        int previousI;
        lock (iLock)
        {
            previousI = i;
            kq = lst[i];
            ++i;
        }
        (sender as BackgroundWorker).ReportProgress(previousI * 100 / listViewEx1.Items.Count);
        ...
    }
