     Object lockObject = new Object();
                try
                    {
    
                        Parallel.ForEach(proxies, new ParallelOptions {MaxDegreeOfParallelism = threads, CancellationToken = _cts.Token}, prox =>
                        {
                            Interlocked.Increment(ref running);
                            Console.WriteLine("thread running: {0}", running);
                            try
                        {
                          lock(lockObject)
                           {
                               //code.............
    
                           }
                    }
                  }
