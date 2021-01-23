        static void Main(string[] args)
        {
            string test = Console.ReadLine();
            System.Diagnostics.Stopwatch t = new System.Diagnostics.Stopwatch();
            t.Start();
            Task<bool> task1 = Task.Run<bool>(() => { return true; });
            Task<bool> task2 = Task.Run<bool>(() => { return true; });
            Task.WaitAll(task1, task2);
            t.Stop();
            Console.WriteLine("Elapsed time: " + t.Elapsed);
            System.Diagnostics.Stopwatch t2 = new System.Diagnostics.Stopwatch();
            t2.Start();
            Task<bool> task3 = asyncMethod1();
            Task<bool> task4 = asyncMethod2();
            Task.WaitAll(task3, task4);
            t2.Stop();
            Console.WriteLine("Elapsed time: " + t2.Elapsed);
            Console.Read();
        }
