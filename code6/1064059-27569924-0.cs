    static class Receiver
        {
            public static object thisLock = new object();
            public static int success;
    
            public static bool hasLocked()
            {
                if(Monitor.TryEnter(thisLock))
                {
                    System.Threading.Thread.Sleep(10);
                    success++;
                    Monitor.Exit(thisLock);
                    return true;
                }
                return false;
            }
        }
