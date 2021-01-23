    public class Schedule
    {
        public enum Type
        { 
            Monthly,
            Weekly
        }
        public Schedule(DayOfWeek weekDay)
        {
            this.ScheduleType = Type.Weekly;
            this.WeekDay = weekDay;
        }
        public Schedule(int monthDay)
        {
            if (monthDay < 1 || monthDay > 31)
                throw new ArgumentException("Invalid day");
            this.ScheduleType = Type.Monthly;
            this.MonthDay = monthDay;
        }
        public Type ScheduleType { get; set; }
        public int MonthDay { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public String Comment { get; set; }
    }
