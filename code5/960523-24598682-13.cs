    public class Project
    {
         public int Id;
         public List<ProjectDependency> Dependencies; 
    }
    public class ProjectDependency
    {
         //..... other property
         public Project DependentProject; 
    }
