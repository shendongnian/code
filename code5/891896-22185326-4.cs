    class UpdateThrottler
    {
        static object lockObject = new object();
        static volatile bool isBusyFlag = false;
    
        static bool CanAcquire()
        {
            if (!isBusyFlag)
                lock(lockObject)
                    if (!isBusyFlag) //could have changed by the time we acquired lock
                        return (isBusyFlag = true);
            return false;
        }
    
        static void Release()
        {
            lock(lockObject)
                isBusyFlag = false;
        }
    }
