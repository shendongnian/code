     public override int SaveChanges()
     {
      ProjectPages
        .Local
        .Where(r => r.Footer!= null && r.FooterId!=default(Guid)).Select(r=>r.Footer)
        .ToList()
        .ForEach(pp=> ProjectPages.Remove(pp));
 
      return base.SaveChanges();
     }
