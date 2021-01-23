        private static readonly TimeSpan timeout = TimeSpan.FromSeconds(10);
        private static readonly object Synchronizer = new { };
        public static void idle()
        {
		    //make sure, it is only called from the Thread that updates.
            AssertThread.Name("MyUpdateThreadName");
            lock (Synchronizer) {
                Monitor.Wait(Synchronizer, timeout);
            }
        }
        public static void nudge()
        {
		    //anyone can call this
            lock (Synchronizer) {
                Monitor.PulseAll(Synchronizer);
            }
        }
		
