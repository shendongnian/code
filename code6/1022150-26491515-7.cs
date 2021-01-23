    class Program
    {
        static void Main(string[] args)
        {
            var process = Process.Start(new ProcessStartInfo
            {
                Arguments = "-argument",
                FileName = "PC.exe"
            });
            while (true)
            {
                Console.WriteLine("Process B, ID: {0},- Hello", Process.GetCurrentProcess().Id);
                Thread.Sleep(1000);
            }
        }
    }
