    public class Time
    {
        [Key]
        public int TimeId { get; set; }
        public int EmployeeID { get; set; }
        public int ProjectID { get; set; }  //<< Changed type from string
        public long? TimeSpent { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        // Set up the other side of the relationship
        public virtual ICollection<Time>{ get; set; } // << Added
    }
    
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public String ProjectNumber { get; set; }
        // Set up the other side of the relationship
        public virtual ICollection<Time>{ get; set; } // << Added
    }
