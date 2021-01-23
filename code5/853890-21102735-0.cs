    static void MyFunction()
    {
        //
        // Use timeGetDevCaps and timeBeginPeriod to set the system timer
        // resolution as close to 1 ms as it will let you.
        //
        var nextTime = DateTime.UtcNow;
        while (!abort)
        {
            // Send your message, preferably do it asynchronously.
            nextTime = nextTime.AddMilliseconds(40);
            var sleepInterval = nextTime - DateTime.UtcNow;
            // may want to check to make sure sleepInterval is positive.
            Thread.Sleep(sleepInterval);
        }
        //
        // Use timeEndPeriod to restore system timer resolution.
        //
    }
