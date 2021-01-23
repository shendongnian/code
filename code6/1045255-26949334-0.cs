    public class TimerWithRunCounter : System.Timers.Timer
    {
        public int Counter { get; set; }
        public TimerWithRunCounter(int counter, double interval) : base(interval)
        {
            Counter = counter;
        }
    }
