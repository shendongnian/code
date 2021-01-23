        public object mutex = new object();
        public void IEAction(string action)
        {
             var th = new Thread(() =>
                {
                    lock(mutex)
                    {
                        //Serialzed code goes here
                    }
                });
             //etc.
        }
