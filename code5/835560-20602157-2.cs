    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App started");
            var timer = new System.Timers.Timer(1800);
            timer.Start();
            timer.Elapsed += timerHandler;
            Console.ReadLine();
        }
        private static void timerHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            Messenger(DateTime.UtcNow.ToString());
        }
        private static void Messenger(string time)
        {
            Console.WriteLine(time);
        }
    }
