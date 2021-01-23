    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                Thread thread = new Thread(DoNothing);
                thread.Start();
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }
        static void DoNothing()
        {
            //Do Nothing
        }
    }
