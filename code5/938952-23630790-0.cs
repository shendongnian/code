    public class TestThreading
    {
        private static System.Object lockThis = new System.Object();
    
        public static void Process()
        {
    
            lock (lockThis)
            {
                // Access thread-sensitive resources.
            }
        }
    
    }
