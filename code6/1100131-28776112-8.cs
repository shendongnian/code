    /// <summary>
    /// Represents a range between two DateTime values
    /// </summary>
    public struct DateTimeRange
    {
        private DateTime _min;
        private DateTime _max;
        public DateTime Min { get { return _min; } }
        public DateTime Max { get { return _max; } }
        /// <summary>
        /// Uses generator to get the start and end dates of this range.
        /// </summary>
        /// <param name="middle">The midpoint of this DateTimeRange</param>
        /// <param name="generator">Generates the min and max dates from the midpoint and a parameter</param>
        public DateTimeRange(DateTime middle, Func<DateTime, int, DateTime> generator, int value)
        {
            _min = generator(middle, -value);
            _max = generator(middle, +value);
        }
        public bool Of(DateTime dateTime)
        {
            return _min <= dateTime && dateTime <= _max;
        }
    }
