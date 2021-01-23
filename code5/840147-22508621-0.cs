    public class DatabasePollingClass {
        object PollingTimerLock = new object();
        ...
        protected void PollingTimerCallback() {
            lock (PollingTimerLock) {
                //Useful stuff here
            }
        }
    }
