    class Dweller
    {
        private static readonly TimeSpan BigGapPeriod = TimeSpan.FromSeconds(0.5);
        private readonly Point _startLocation;
        private readonly DateTimeOffset _startTime;
        private readonly DateTimeOffset _currentTime;
        private readonly TimeSpan _durationInFence;
        private static readonly TimeSpan CompleteTime = TimeSpan.FromSeconds(1);
        public Dweller()
            : this(new Point(), DateTimeOffset.MinValue, DateTimeOffset.MinValue)
        { }
        private Dweller(Point startLocation, DateTimeOffset startTime, DateTimeOffset currentTime)
        {
            _startLocation = startLocation;
            _startTime = startTime;
            _currentTime = currentTime;
            _durationInFence = currentTime - _startTime;
        }
        public TimeSpan DurationInFence
        {
            get { return _durationInFence; }
        }
        public double Percentage
        {
            get { return RoundDown(Math.Min(_durationInFence.Ticks / (double)CompleteTime.Ticks, 1.0), 1); }
        }
        public Dweller CreateNext(Point location, DateTimeOffset now)
        {
            if (IsInitialValue() || !IsWithinFence(location) || HasCompleted() || IsNewSequence(now))
            {
                return new Dweller(location, now, now);
            }
            return new Dweller(_startLocation, _startTime, now);
        }
        private bool IsNewSequence(DateTimeOffset now)
        {
            return now > (_currentTime + BigGapPeriod);
        }
        private bool HasCompleted()
        {
            return Percentage == 1.0;
        }
        private bool IsInitialValue()
        {
            return _startTime == DateTimeOffset.MinValue;
        }
        private bool IsWithinFence(Point point)
        {
            //Put your own logic here
            return Math.Abs(point.X - _startLocation.X) < 100
                   && Math.Abs(point.Y - _startLocation.Y) < 100;
        }
        private static double RoundDown(double i, double decimalPlaces)
        {
            var power = Math.Pow(10, decimalPlaces);
            return Math.Floor(i * power) / power;
        }
    }
