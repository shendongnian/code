        static object syncObj = new object();
        private void Handler(object oSource,
            ElapsedEventArgs oElapsedEventArgs)
        {
            lock(syncObj)
            {
               if(isRunning) return;            
               isRunning = true;
            }
            try
            {
               Console.WriteLine("foo");
               Thread.Sleep(500);         //simulate some work
               Console.WriteLine("bar");
            }
            finally { lock(syncObj) { isRunning = false; } }            
        }
