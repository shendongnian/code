    public class Project
    {
         public int Id;
         ...  
         public IList<Project> ProjectDependencies { get; set; }
         public Project ParentProject Project { get; set; }     
    }
