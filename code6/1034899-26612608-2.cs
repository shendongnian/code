    public class Rooster
    {
        public long startDate { get; set; }
        public long endDate { get; set; }
        public string moduleCode { get; set; }
        public string activityDescription { get; set; }
        public List<object> staffMembers { get; set; }
        public List<Location> locations { get; set; }
        public List<string> studentSets { get; set; }
        public string activityTypeName { get; set; }
        public object activityTypeDescription { get; set; }
        public object notes { get; set; }
        public bool highlighted { get; set; }
        public List<string> timetableKeys { get; set; }
    }
