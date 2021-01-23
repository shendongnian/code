    public struct DateSpan
    {
        public DateTime Begin
        {
            get
            {
                return this.begin;
            }
        }
        public DateTime End
        {
            get
            {
                return this.end;
            }
        }
        public TimeSpan TimeSpan
        {
            get
            {
                return this.End - this.Begin;
            }
        }
        public TimeSpan GetWorkTimeSpan(TimeSpan? workTimeBegin, TimeSpan? workTimeEnd)
        {
            if (this.Begin.Date == this.End.Date)
            {
                long totalWorkTimeTicks = Math.Min(workTimeEnd.Value.Ticks, this.End.TimeOfDay.Ticks) - Math.Max(workTimeBegin.Value.Ticks, this.Begin.TimeOfDay.Ticks);
                return TimeSpan.FromTicks(totalWorkTimeTicks);
            }
            else
            {
                TimeSpan daySpan = this.End.Date - this.Begin.Date;
                TimeSpan dailyWorkTime = TimeSpan.FromDays(1);
                dailyWorkTime -= workTimeBegin ?? TimeSpan.Zero;
                dailyWorkTime -= TimeSpan.FromDays(1) - workTimeEnd ?? TimeSpan.FromDays(1);
                long totalDaysWorkTimeTicks = (int)(daySpan.TotalDays - 1) * dailyWorkTime.Ticks;
                long firstDayWorkTimeTicks = Math.Min(dailyWorkTime.Ticks, Math.Max(0, (workTimeEnd ?? TimeSpan.FromDays(1)).Ticks - this.Begin.TimeOfDay.Ticks));
                long lastDayWorkTimeTicks = Math.Min(dailyWorkTime.Ticks, Math.Max(0, this.End.TimeOfDay.Ticks - (workTimeBegin ?? TimeSpan.Zero).Ticks));
                return TimeSpan.FromTicks(firstDayWorkTimeTicks + totalDaysWorkTimeTicks + lastDayWorkTimeTicks);
            }
        }
    }
