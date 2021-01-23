    internal class Program
    {
        private static void Main(string[] args)
        {
            RedirectProcess.StartGrab("PB.exe", Console.WriteLine);
            while (true)
            {
                Console.WriteLine("Process A, ID: {0},- Hello", Process.GetCurrentProcess().Id);
                Thread.Sleep(1000);
            }
        }
    }
