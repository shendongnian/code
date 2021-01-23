    var local = yourDbContext.Set<YourModel>()
                             .Local
                             .FirstOrDefault(f => f.Id == yourModel.Id);
    if (local != null)
    {
      yourDbContext.Entry(local).State = EntityState.Detached;
    }
    yourDbContext.Entry(applicationModel).State = EntityState.Modified;
