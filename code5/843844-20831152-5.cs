    private static async Task<string> Foo(long seconds)
        {
            return await Task.Factory.StartNew((status) =>
            {
                for (int i = 1; i < 10; i++)
                {
                    Console.WriteLine("Thread ID: {0}, second {1}.", Thread.CurrentThread.ManagedThreadId, i);
                    taskStatus = TaskStatus.Running;
                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                }
                taskStatus = TaskStatus.RanToCompletion;
                return "Foo Completed.";
            }, taskStatus);
        }
