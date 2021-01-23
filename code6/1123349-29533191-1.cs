    public class Project
    {
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Planner { get; set; }
        public DateTime ScheduleStart { get; set; }
        public DateTime ScheduleEnd { get; set; }
        public double EstimatedCost { get; set; }
        public double ActualCost { get; set; }
        public string AssignedTo { get; set; }
        public Project Clone()
        {
            // If your object has inner collections, you'll have to deep
            // clone them ***manually***!!!
            return (Project)MemberwiseClone();
        }
    }
