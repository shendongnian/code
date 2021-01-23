    namespace NavigateBot
    {
        class BotNavigation
        {
            private readonly object _serialLock = new object();
    
            [MethodImpl(MethodImplOptions.Synchronized)]
            public void TakeForward(int distanceTime, SerialPort port)
            {
                int count = 0;
                
                ThreadPool.QueueUserWorkItem(
                delegate
                {
                    lock (_serialLock)
                    {
                        while (count < distanceTime)
                        {
                            port.WriteLine("F");
                            Thread.Sleep(distanceTime*250);
                            count++;
                        }
                    }
                });
            }
    		
    		...
    		
            [MethodImpl(MethodImplOptions.Synchronized)]
            public void TurnLeft(int distanceTime, SerialPort port)
            {
                int count = 0;
            
                ThreadPool.QueueUserWorkItem(
                delegate
                {
                    lock (_serialLock)
                    {
                        while (count < distanceTime)
                        {
                            port.WriteLine("L");
                            Thread.Sleep(distanceTime*250);
                            count++;
                        }
                    }
                });
            }
    		
    		...
    	}
    }
