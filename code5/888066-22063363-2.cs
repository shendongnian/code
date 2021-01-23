    class MyClass
    {
        private object myLock = new object();
        private int state;
    
        public void Method1()
        {
            lock (myLock)
            {
                state = // ...
            }
        }
    
        public void Method2()
        {
            myLock = new object();
            lock (myLock)
            {
                state = // ...
            }
        }
    }
