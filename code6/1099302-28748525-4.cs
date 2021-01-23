    public override int SaveChanges()
    {
      ProjectPages
        .Local
        .Where(r => r.Footer== null && r.FooterId!=default(Guid)).Select(r=>r.FooterId)
        .ToList()
        .ForEach(id => ProjectPages.Remove(ProjectPages.Find(id)));
 
      return base.SaveChanges();
    }
