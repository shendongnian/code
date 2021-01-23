    public class Project
    {
         public int Id;
         // ...   other properties here
         public IList<Project> ProjectDependencies { get; set; }
         public Project ParentProject Project { get; set; }     
    }
