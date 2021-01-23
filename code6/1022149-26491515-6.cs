    internal class Program
    {
        private static void Main(string[] args)
        {
            var server = new RediretServer();
            server.ProcessDataReceived += (s, e) => Console.WriteLine("pid:{0}, data:{1}", e.Id, e.Data);
            RedirectProcess.StartGrab("PB.exe", Console.WriteLine);
            while (true)
            {
                Console.WriteLine("Process A, ID: {0},- Hello", Process.GetCurrentProcess().Id);
                Thread.Sleep(1000);
            }
        }
    }
