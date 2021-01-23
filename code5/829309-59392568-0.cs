        static async Task Wait(int delay, double[] errors, int index)
        {
            var sw = new Stopwatch();
            sw.Start();
            await Task.Delay(delay);
            sw.Stop();
            errors[index] = Math.Abs(sw.ElapsedMilliseconds - delay);
        }
        static void Main(string[] args)
        {
            var trial = 100000;
            var minDelay = 1000;
            var maxDelay = 5000;
            var errors = new double[trial];
            var tasks = new Task[trial];
            var rand = new Random();
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < trial; i++)
            {
                var delay = rand.Next(minDelay, maxDelay);
                tasks[i] = Wait(delay, errors, i);
            }
            sw.Stop();
            Console.WriteLine($"{trial} tasks started in {sw.ElapsedMilliseconds} milliseconds.");
            Task.WaitAll(tasks);
            Console.WriteLine($"Avg Error: {errors.Average()}");
            Console.WriteLine($"Min Error: {errors.Min()}");
            Console.WriteLine($"Max Error: {errors.Max()}");
            Console.ReadLine();
        }
