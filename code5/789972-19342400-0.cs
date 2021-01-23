    class Program
    {
        private static Timer _timer = new Timer();
        private static DateTime _last = DateTime.Now;
        private const int IntendedInterval = 25;
        static void Main(string[] args)
        {
            _timer.AutoReset = false;
            _timer.Interval = (int)(IntendedInterval / 16) * 16;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
            Console.ReadLine();
        }
        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var now = DateTime.Now;
            var duration = now - _last;
            var sleep = IntendedInterval - duration.TotalMilliseconds;
            if (0 < sleep )
            {
                System.Threading.Thread.Sleep(( int )sleep);
            }
            _timer.Start();
            now = DateTime.Now;
            duration = now - _last;
            _last = now;
            Console.WriteLine(duration.TotalMilliseconds.ToString());
        }
    }
