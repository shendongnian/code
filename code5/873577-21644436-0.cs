    using System;
    public class AClass
    {
        private System.Timers.Timer _timer;
		private DateTime _startTime;
        public void Start()
        {
			_startTime = DateTime.Now;
			_timer = new System.Timers.Timer(1000*10); // 10 seconds
            _timer.Elapsed += timer_Elapsed;
            _timer.Enabled = true;
            Console.WriteLine("Timer has started");
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimeSpan timeSinceStart = DateTime.Now - _startTime;
            string output = string.Format("{0},{1}\r\n", DateTime.Now.ToLongDateString(), (int) Math.Floor( timeSinceStart.TotalMinutes));
            Console.Write(output);
        }
    }
