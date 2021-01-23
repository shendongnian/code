    public class JobViewModel
    {
      public int Id { get; set; }
      public string Description { get; set; }
      public virtual List<JobAssemblyViewModel> Children { get; set; }
    }
    public class JobAssemblyViewModel
    {
      public int Id { get; set; }
      public virtual List<JobAssemblyViewModel> Children { get; set; }
    }
