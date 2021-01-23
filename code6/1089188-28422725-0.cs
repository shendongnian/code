    public struct DateSpan
    {
        public DateTime begin, end;
        public DateSpan(DateTime begin, DateTime end)
        {
            if (begin > end || end < begin)
                throw new Exception("Not possible");
            this.begin = begin;
            this.end = end;
        }
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
                long totalWorkTimeTicks = Math.Min(workTimeEnd.Value.Ticks, this.End.Ticks) - Math.Max(workTimeBegin.Value.Ticks, this.Begin.Ticks);
                return TimeSpan.FromTicks(totalWorkTimeTicks);
            }
            else
            {
                TimeSpan dailyWorkTime = TimeSpan.FromDays(1);
                dailyWorkTime -= workTimeBegin ?? TimeSpan.Zero;
                dailyWorkTime -= TimeSpan.FromDays(1) - workTimeEnd ?? TimeSpan.FromDays(1);
                
                long totalDaysWorkTimeTicks = (int)(this.TimeSpan.TotalDays) * dailyWorkTime.Ticks;
                long firstDayWorkTimeTicks = Math.Min(dailyWorkTime.Ticks, Math.Max(0, workTimeEnd.Value.Ticks - this.Begin.TimeOfDay.Ticks));
                long lastDayWorkTimeTicks = Math.Min(dailyWorkTime.Ticks, Math.Max(0, this.End.TimeOfDay.Ticks - workTimeBegin.Value.Ticks));
                return TimeSpan.FromTicks(firstDayWorkTimeTicks + totalDaysWorkTimeTicks + lastDayWorkTimeTicks);
            }
        }
    }
