    // Dummy object to the used as a mutual-exclusion lock when synchronizing threads.
    private static readonly object syncLock = new object();
    public static void Main(string[] args)
    {
        // Run two anonymous functions in parallel,
        // then waiting for both to complete.
        Parallel.Invoke(
            () =>
            {
                string loading = "LOADING...";
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < loading.Length; j++)
                    {
                        // Critical section
                        lock (syncLock)
                        {
                            Console.SetCursorPosition(j, 0);
                            Console.Write("{0}", loading[j]);
                        }
                        Thread.Sleep(250);
                    }
                    // Critical section
                    lock (syncLock)
                    {
                        Console.SetCursorPosition(5, 0);
                        Console.Write("\r          ");
                    }
                }
            },
            () =>
            {
                for (int k = 0; k <= 100; k++)
                {
                    // Critical section
                    lock (syncLock)
                    {
                        Console.SetCursorPosition(0, 1);
                        Console.Write("\r{0}%", k);
                    }
                    Thread.Sleep(150);
                }
            });
        }
    }
        
