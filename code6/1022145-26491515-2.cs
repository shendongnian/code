    class Program
    {
        static void Main(string[] args)
        {
            RedirectProcess.StartRedirected("PC.exe");
            while (true)
            {
                Console.WriteLine("Process B, ID: {0},- Hello", Process.GetCurrentProcess().Id);
                Thread.Sleep(1000);
            }
        }
    }
