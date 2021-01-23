    public class TimeWindow
    {
        private TimeSpan duration;
        public DateTime StartTime { get; set; }
        public DateTime EndTime
        {
            get
            {
                return this.StartTime.Add(this.duration);
            }
            set
            {
                // this will throw a ArgumentOutOfRangeException if value is smaller than StartTime
                this.duration = value.Subtract(this.StartTime);
            }
        }
        public void SetStartAndEnd(DateTime start, DateTime end)
        {
            this.StartTime = start;
            this.EndTime = end;
        }
    }
