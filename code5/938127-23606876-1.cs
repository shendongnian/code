    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var total = CreateMultipleTasks();
            total.Wait();
            stopwatch.Stop();
    
            Console.WriteLine("Total jobs done: {0} ms", total.Result);
            Console.WriteLine("Jobs done in: {0} ms", stopwatch.ElapsedMilliseconds);
        }
    
        static async Task<int> CreateMultipleTasks()
        {
            var task1 = Task.Run(() => WaitForMeAsync(5000));
            var task2 = Task.Run(() => WaitForMeAsync(3000));
            var task3 = Task.Run(() => WaitForMeAsync(4000));
            await Task.WhenAll(new Task[] { task1, task2, task3 });
    
            return task1.Result + task2.Result + task3.Result;
        }
    
        static int WaitForMeAsync(int ms)
        {
            // assume Thread.Sleep is a placeholder for a CPU-bound work item
            Thread.Sleep(ms);
            return ms;
        }
    }
