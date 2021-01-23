    // Model
    public class test
    {
        public string TimeZoneId { get; set; }
        public TimeZoneInfo TimeZone 
        { 
            get { return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId); }
            set { TimeZoneId = value.Id; } 
        }
    }
