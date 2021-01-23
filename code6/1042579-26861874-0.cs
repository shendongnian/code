    public class Actor
    {
        public int ID { get; set; }
        public int projectID { get; set; }
        public virtual Project project { get; set; } 
        public string Title { get; set; }
    
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
