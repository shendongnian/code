    public static class DateTimeExtensions
    {
        /// <summary>
        /// <para>Specify exactly one of milliseconds, seconds, minutes, hours, days, months, or years.</para>
        /// <para>Uses the first nonzero argument in the order specified.</para>
        /// </summary>
        public static DateTimeRange IsWithin(
            this DateTime dateTime,
            int milliseconds = 0, int seconds = 0, int minutes = 0, int hours = 0,
            int days = 0, int months = 0, int years = 0)
        {
            if ( milliseconds != 0 )
                return new DateTimeRange(dateTime, (_dateTime, _value) => _dateTime.AddMilliseconds(_value), milliseconds);
            if ( seconds != 0 )
                return new DateTimeRange(dateTime, (_dateTime, _value) => _dateTime.AddSeconds(_value), seconds);
            if ( minutes != 0 )
                return new DateTimeRange(dateTime, (_dateTime, _value) => _dateTime.AddMinutes(_value), minutes);
            if ( hours != 0 )
                return new DateTimeRange(dateTime, (_dateTime, _value) => _dateTime.AddHours(_value), hours);
            if ( days != 0 )
                return new DateTimeRange(dateTime, (_dateTime, _value) => _dateTime.AddDays(_value), days);
            if ( months != 0 )
                return new DateTimeRange(dateTime, (_dateTime, _value) => _dateTime.AddMonths(_value), months);
            if ( years != 0 )
                return new DateTimeRange(dateTime, (_dateTime, _value) => _dateTime.AddYears(_value), years);
            throw new ArgumentException("At least one value must be nonzero");
        }
    }
