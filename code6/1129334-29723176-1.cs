    public class Meter
    {
        private Timer ReadingTime;
        public Meter() {
            ReadingTime = new Timer();
            ReadingTime.AutoReset = false;
            ReadingTime.Elapsed += new ElapsedEventHandler(PerformReading);
            ReadingTime.Interval = GetInterval();
        }
        public void StartMeter()
        {
            ReadingTime.Start();
        }
        static double GetInterval()
        {
            return 1000 - DateTime.Now.Millisecond;
        }
        private void PerformReading(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Performing reading: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "." + DateTime.Now.Millisecond);
            ReadingTime.Interval = GetInterval();
        }
    }
