    public class DatabasePollingClass {
        object PollingTimerLock = new object();
        ...
        protected void PollingTimerCallback() {
            if (Monitor.TryEnter(PollingTimerLock)) { //Acquires lock on PollingTimerLock object
                try {
                    //Useful stuff here
                } finally {
                    //Releases lock.
                    //You MUST do this in a finally block! (See below.)
                    Monitor.Exit(PollingTimerLock);
                }
            } else {
                Console.WriteLine("Warning: Polling timer overlap. Skipping.");
            }
        }
    }
