    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int? AssignedUserId { get; set; }
        [ForeignKey("AssignedUserId")]
        public virtual User User { get; set; }
    }
