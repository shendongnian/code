            CancellationTokenSource cts = new CancellationTokenSource();
            Task.Factory.StartNew(() =>
                {
                    while (1 == 1)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Thread1 in progress...");
                        if (cts.Token.IsCancellationRequested)
                        {
                            Console.WriteLine("Thread1 exiting...");
                            break;
                        }
                    }
                }, cts.Token);
            Task.Factory.StartNew(() =>
                {
                    while (1 == 1)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Thread2 in progress...");
                        if (cts.Token.IsCancellationRequested)
                        {
                            Console.WriteLine("Thread2 exiting...");
                            break;
                        }
                    }
                }, cts.Token);
            Task.Factory.StartNew(() =>
            {
                while (1 == 1)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Thread3 in progress...");
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Thread3 exiting...");
                        break;
                    }
                }
            }, cts.Token);
            Task.Factory.StartNew(() =>
            {
                
                Thread.Sleep(5000);
                try
                {
                    Console.WriteLine("Thread5 in progress...");
                    int y = 0;
                    int x = 1 / y;
                }
                catch 
                {
                    Console.WriteLine("Thread5 requesting cancellation...");
                    cts.Cancel();
                }
            }, cts.Token);
