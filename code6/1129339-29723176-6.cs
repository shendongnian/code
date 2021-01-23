    public class Meter
    {
        private Timer ReadingTime;
        private DateTime NextTickTimeWholeSeconds;
        public Meter() {
            DateTime now = DateTime.UtcNow;
            NextTickTimeWholeSeconds = new DateTime(now.Ticks - (now.Ticks % TimeSpan.TicksPerSecond), now.Kind);
            ReadingTime = new Timer();
            ReadingTime.AutoReset = false;
            ReadingTime.Elapsed += new ElapsedEventHandler(PerformReading);
            ReadingTime.Interval = GetTimeToNextSecond();
        }
        public void StartMeter()
        {
            ReadingTime.Start();
        }
        private double GetTimeToNextSecond()
        {
            NextTickTimeWholeSeconds = NextTickTimeWholeSeconds.AddSeconds(1);
            var interval = NextTickTimeWholeSeconds - DateTime.UtcNow;
            return interval.Milliseconds < 1 ? GetTimeToNextSecond() : interval.Milliseconds;
        }
        private void PerformReading(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Performing reading: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "." + DateTime.Now.Millisecond);
            ReadingTime.Interval = GetTimeToNextSecond();
        }
    }
