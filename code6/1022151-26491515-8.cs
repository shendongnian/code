    class Program
    {
        static void Main(string[] args)
        {
            var a = args.Length == 0 ? "default" : args[0];
            while (true)
            {
                Console.WriteLine("Process C, ID: {0}, Args: {1}- Hello", Process.GetCurrentProcess().Id, a);
                Thread.Sleep(1000);
            }
        }
    }
