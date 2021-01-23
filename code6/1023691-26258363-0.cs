    public class TimeSlot : EntityBase
    {
        public virtual TimeSpan FromTime { get; set; }
        public virtual TimeSpan ToTime { get; set; }
    }
