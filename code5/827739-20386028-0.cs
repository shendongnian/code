    if (SizeQueueProperty.Waiting)
    {
        Log.Info("Waiting for continue on crawling");
        Monitor.Wait(SizeQueueProperty.Locker);
    }
