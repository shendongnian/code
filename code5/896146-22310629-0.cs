    public class MultiThreadClass
    {
        public void Gogogo()
        {
            if (Interlocked.Exchange(ref running, 1) == 0)
            {
                //Do stuff
                running = 0;
            }
        }
        private volatile int running = 0;
    }
