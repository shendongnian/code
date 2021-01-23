    public class Project
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public ICollection<Sprint> Sprints { get; set; } // new
        public long? BacklogId { get; set; } // changed
        public Sprint Backlog { get; set; }
    }
    
    public class Sprint
    {
        public long ID { get; set; }
        public string Name { get; set; }
    
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
