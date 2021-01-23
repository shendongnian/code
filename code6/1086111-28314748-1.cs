    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++) {
            int i2 = i + 1;
            Stopwatch t = new Stopwatch();
            t.Start();
            Task.Run(async () => {
                t.Stop();
                Console.ForegroundColor = ConsoleColor.Green; //Note that the other tasks might manage to write their lines between these colour changes messing up the colours.
                Console.WriteLine("Task " + i2 + " started after " + t.Elapsed.Seconds + "." + t.Elapsed.Milliseconds + "s");
                await Task.Delay(5000);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Task " + i2 + " finished");
            });
        }
        Console.ReadKey();
    }
