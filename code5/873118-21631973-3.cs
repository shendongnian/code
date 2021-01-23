    sealed class Player : IPlayer
    {
        static readonly TimeSpan OneSecondDelay = TimeSpan.FromSeconds(1);
        static readonly int InitialSeconds = 60;
        TaskTimer timer;
        long remainingSeconds;
        public int RemainingSeconds
        {
            get { return (int)Interlocked.Read(ref remainingSeconds); }
        }
        public Player()
        {
            ResetTimer(InitialSeconds);
            timer = new TaskTimer(OneSecondDelay, TimerTick);
            timer.Start();
        }
        void ResetTimer(int seconds)
        {
            Interlocked.Exchange(ref remainingSeconds, seconds);
        }
        void TimerTick()
        {
            var newValue = Interlocked.Decrement(ref remainingSeconds);
            if (newValue <= 0)
            {
                // Timer has expired!
                ResetTimer(InitialSeconds);
            }
        }
    }
