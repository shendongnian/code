       private Object thisLock = new Object();
        public void MyThreadMethod()
        {
            lock (thisLock)
            {
               // Accessing common resources
            }
        }
