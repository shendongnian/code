	[Serializable]
	public class MonthIntervalCalendar : BaseCalendar
	{
        DateTime _startAt;
        int _interval;
        /// <summary>
        /// Initializes a new instance of the <see cref="MonthIntervalCalendar"/> class.
        /// </summary>
		public MonthIntervalCalendar(DateTime startAt, int interval)
		{
            _startAt = startAt;
            _interval = interval;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="MonthIntervalCalendar"/> class.
        /// </summary>
        /// <param name="baseCalendar">The base calendar.</param>
		public MonthIntervalCalendar(DateTime startAt, int interval, ICalendar baseCalendar)
		{
            _startAt = startAt;
            _interval = interval;
            CalendarBase = baseCalendar;
		}
        
        public override bool IsTimeIncluded(DateTimeOffset timeStampUtc)
		{
            if (!base.IsTimeIncluded(timeStampUtc))
                return false;
            if (timeStampUtc < _startAt)
                return false;
            var months = (timeStampUtc.Month - _startAt.Month) + 12 * (timeStampUtc.Year - _startAt.Year);
            var included = months % _interval == 0;
            return included;
		}
		/// <summary>
		/// Determine the next time (in milliseconds) that is 'included' by the
		/// Calendar after the given time.
		/// <para>
		/// Note that this Calendar is only has full-day precision.
		/// </para>
		/// </summary>
        public override DateTimeOffset GetNextIncludedTimeUtc(DateTimeOffset timeUtc)
		{
            timeUtc = base.GetNextIncludedTimeUtc(timeUtc);
            while (!IsTimeIncluded(timeUtc))
            {
                var nextTime = timeUtc.AddMonths(1);
                timeUtc = base.GetNextIncludedTimeUtc( new DateTime(nextTime.Year, nextTime.Month, 1) );
            }
            return timeUtc;
		}
	    /// <summary>
	    /// Creates a new object that is a copy of the current instance.
	    /// </summary>
	    /// <returns>A new object that is a copy of this instance.</returns>
	    public override object Clone()
	    {
            MonthIntervalCalendar clone = (MonthIntervalCalendar)base.Clone();
            clone._interval = _interval;
            clone._startAt = _startAt;
            return clone;
	    }
        public override int GetHashCode()
        {
            int baseHash = 0;
            if (GetBaseCalendar() != null)
                baseHash = GetBaseCalendar().GetHashCode();
            return _startAt.GetHashCode() + _interval + 5 * baseHash;
        }
        public bool Equals(MonthIntervalCalendar obj)
        {
            if (obj == null)
                return false;
            bool baseEqual = GetBaseCalendar() == null || GetBaseCalendar().Equals(obj.GetBaseCalendar());
            return baseEqual && obj._startAt.Equals(_startAt) && obj._interval.Equals(_interval);
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is MonthIntervalCalendar))
                return false;
            return Equals((MonthIntervalCalendar)obj);
        }
	}
