    public override int SaveChanges()
    {
      ProjectPages
        .Local
        .Where(r => r.Footer== null)
        .ToList()
        .ForEach(r => ProjectPages.Remove(r));
 
      return base.SaveChanges();
    }
