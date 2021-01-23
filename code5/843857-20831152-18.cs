    var task = Task.Run(() =>
            {
                for (int i = 10; i < 432543543; i++)
                {
                    // just for a long job
                    double d3 = Math.Sqrt((Math.Pow(i, 5) - Math.Pow(i, 2)) / Math.Sin(i * 8));
                }
               return "Foo Completed.";
               
            });
            
            while (task.Status != TaskStatus.RanToCompletion)
            {
                Console.WriteLine("Thread ID: {0}, Status: {1}", Thread.CurrentThread.ManagedThreadId,task.Status);
                
            }
            Console.WriteLine("Result: {0}", task.Result);
            Console.WriteLine("Finished.");
            Console.ReadKey(true);
