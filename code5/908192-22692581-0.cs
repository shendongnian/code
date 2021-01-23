    public abstract class JobAssembly
    {
        public int Id { get; set; }
        public virtual List<SubAssembly> SubAssemblies { get; set; }
    }
    public class SubAssembly : JobAssembly
    {
        public int ParentAssemblyId { get; set; }
        public virtual JobAssembly ParentAssembly { get; set; }
    }
    public class RootAssembly : JobAssembly
    {
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
    }
    public class Job
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual List<RootAssembly> Assemblies { get; set; }
    }
