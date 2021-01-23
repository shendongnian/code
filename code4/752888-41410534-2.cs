        static void Main(string[] args)
        {
            var task = Run();
            task.Wait();
        }
        public static async Task Run()
        {
            Task[] tasks = new[] { CreateTask("ex1"), CreateTask("ex2") };
            var compositeTask = Task.WhenAll(tasks);
            try
            {
                await compositeTask.ContinueWith((antecedant) => { }, TaskContinuationOptions.ExecuteSynchronously);
                compositeTask.Wait();
            }
            catch (AggregateException aex)
            {
                foreach (var ex in aex.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static Task CreateTask(string message)
        {
            return Task.Factory.StartNew(() => { throw new Exception(message); });
        }
