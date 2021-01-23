    class Account
    {
        int count;
        private Object thisLock = new Object();
        public void Add(decimal amount)
        {
            //your code
            lock (thisLock)
            {
               count++;
            }
        }
    }
