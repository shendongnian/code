        private static AggregateException exception = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            
            Task.Factory.StartNew(PrintTime, CancellationToken.None).ContinueWith(HandleException, TaskContinuationOptions.OnlyOnFaulted);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Master Thread i={0}", i + 1);
                Thread.Sleep(1000);
                if (exception != null)
                {
                    break;
                }
            }
            Console.WriteLine("Finish");
            Console.ReadLine();
        }
        private static void HandleException(Task task)
        {
            exception = task.Exception;
            Console.WriteLine(exception);
        }
        private static void PrintTime()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Inner Thread i={0}", i + 1);
                Thread.Sleep(1000);
            }
            throw new Exception("exception");
        }
