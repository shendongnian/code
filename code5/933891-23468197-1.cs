    public class Project {
        public ICollection<ProjectUser> Users { get; set; }
    }
    
    public class ProjectUser {
        public Project Project { get; set; }
        public User User { get; set; }
        public bool IsRequired { get; set; }
    }
    
    public class User {
        public ICollection<ProjectUser> Projects { get; set; }
    }
