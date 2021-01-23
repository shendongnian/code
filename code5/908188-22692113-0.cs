    public class Job
    {
      public int Id { get; set; }
      public string Description { get; set; }
      public virtual List<JobAssembly> Assemblies { get; set; }
      public IEnumerable<JobAssembly> DirectChildren
      {
        get
        {
          return this.Assemblies == null
            ? null
            : this.Assemblies.Where(x => x.ParentAssemblyId == null);
        }
      }
    }
