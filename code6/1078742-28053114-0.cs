    public class Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
    }
    public class DTO
    {
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Start { get { return StartDate.Add(StartTime.TimeOfDay); } }
    }
