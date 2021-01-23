    namespace NavigateBot
    {
        class BotNavigation
        {
            private readonly object _serialLock = new object();
    
            [MethodImpl(MethodImplOptions.Synchronized)]
            public void TakeForward(int distanceTime)
            {
                int count = 0;
                System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    lock (_serialLock)
                    {
                        while (count < distanceTime)
                        {
                            Console.Out.WriteLine("F");
                            Thread.Sleep(distanceTime*250);
                            count++;
                        }
                    }
                }));
    
                thread.IsBackground = true;
                thread.Start();
            }
    		
    		...
    		
            [MethodImpl(MethodImplOptions.Synchronized)]
            public void TurnLeft(int distanceTime)
            {
                int count = 0;
                System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    lock (_serialLock)
                    {
                        while (count < distanceTime)
                        {
                            Console.Out.WriteLine("L");
                            Thread.Sleep(distanceTime*250);
                            count++;
                        }
                    }
                }));
    
                thread.IsBackground = true;
                thread.Start();
            }
    		
    		...
    	}
    }
