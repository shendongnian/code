    public class Project
    {
         public int Id;
         public List<ProjectDependency> Dependencies;   //that is a cycle and it is very bad architecture
    }
