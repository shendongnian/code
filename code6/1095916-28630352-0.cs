    static void Main()
    {
        TaskScheduler.UnobservedTaskException += (s, e) =>
        {
            Console.WriteLine("From unobserved exception handler: {0}", e.Exception.Message);
        };
        RunTask();
        int gcCounter = 0;
        while (true)
        {
            // artifical memory consumption
            int[][] a = new int[4096][];
            for (int j = 0; j < 4096; j++)
                a[j] = new int[4096];
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("Garbage collected: {0}", ++gcCounter);
            Thread.Sleep(500);
        }
    }
    static void RunTask()
    {
        var faultedTask = Task.Factory.StartNew(() => { throw new Exception("Task is faulted"); });
        // 1. ContinueWhenAll hides unobserved exception
        Task.Factory.ContinueWhenAll(new[] { faultedTask }, ts =>
        {
            Console.WriteLine("From \"when all\" continuation");
        });
        // 2. Simple continuation does not hide unobserved exception
        //faultedTask.ContinueWith(t => { Console.WriteLine("From \"simple\" continuation"); });
    }
