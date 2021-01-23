        static object _sync = new object();
        public void someFun1(Object obj)
        {
            lock (_sync)
            {
                Console.WriteLine("Start1 " + DateTime.Now);
            }
        }
        public void changeTime1(Object obj)
        {
            lock (_sync)
            {
                someTime1.Change(0, 2000);
            }            
        }
