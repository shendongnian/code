    class TimerContext
    {
        private readonly int _timerCount;
        public int TimerCount { get { return _timerCount; } }
        public TimerContext(int timerCount)
        {
            _timerCount = timerCount;
        }
        public void GetMainStuff()
        {
            GetThisStuff();
            GetOtherStuff();
        }
    
        public void GetMoreMainStuff()
        {
            GetFinalStuff();
        }
        // etc.
    }
    public static void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        TimerContext context = new TimerContext(Interlocked.Increment(ref _timerCounter));
        context.GetMainStuff();
        context.GetMoreMainStuff();
    }
