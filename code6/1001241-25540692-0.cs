        public static void TaskCancellationTestNotWorking1()
        {
            try
            {
                Console.WriteLine("TaskCancellationTestNotWorking started.");
                var cts = new CancellationTokenSource();
                var t = Task.Run(() =>
                {
                    Console.WriteLine("1");
                    Thread.Sleep(2000);
                    Console.WriteLine("2");
                }, cts.Token).ContinueWith(task =>
                {
                    Console.WriteLine("3");
                    Thread.Sleep(2000);
                    cts.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("4");
                });
                Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Cancelling...");
                    cts.Cancel();
                }, cts.Token);
                try
                {
                    t.Wait();
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("IsCanceled " + t.IsCanceled);
                    Console.WriteLine("IsCompleted " + t.IsCompleted);                    
                    Console.WriteLine("Gracefully canceled.");
                }
                catch (AggregateException)
                {
                    Console.WriteLine("IsCanceled " + t.IsCanceled);
                    Console.WriteLine("IsCompleted " + t.IsCompleted);
                    Console.WriteLine("Gracefully canceled 1.");
                }
                Console.WriteLine("TaskCancellationTestNotWorking completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("TaskCancellationTestNotWorking... Failure: " + ex);
            }
        }
