    public class DoSomeWork
    {
        public void Execute()
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Starting");
            Thread.Sleep(500);
            Console.WriteLine("Done");
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
