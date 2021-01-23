    public class OnPeriod
    {
        public DateTime OnDate { get; set; }
        public DateTime OffDate { get; set; }
        public TimeSpan OnTime {get { return OffDate.Subtract(OnDate); }}
    }
