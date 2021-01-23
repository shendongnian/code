    public class Project
    {
        public int Id;
        public ISet<ProjectDependency> Dependencies;   
    }
    public class ProjectDependency
    {
        public Project Project;
        public Project Dependency;
        // This is a simplified version and don't check for nulls in internal members
        // or transient objects
        public override int GetHashCode()
        {
            return this.Project.Id + this.Dependency.Id;
        }
        // This is a simplified version and don't check for nulls in internal members
        // or transient objects
        public override bool Equals(object obj)
        {
            var dep = obj as ProjectDependency;
            if (dep == null)
            {
                return false;
            }
    
            return this.Project.Id == dep.Project.Id && this.Dependency.Id == dep.Dependency.Id;
        }
    }
