    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }
        private void Print(string txt)
        {
            string dateStr = DateTime.Now.ToString("HH:mm:ss.fff");
            Console.WriteLine($"{dateStr} Thread #{Thread.CurrentThread.ManagedThreadId}\t{txt}");
        }
        private void Run()
        {
            Print("Program Start");
            Experiment().Wait();
            Print("Program End. Press any key to quit");
            Console.Read();
        }
        private async Task Experiment()
        {
            Print("Experiment code is synchronous before await");
            await Task.Delay(500);
            Print("Experiment code is asynchronous after first await");
        }
    }
