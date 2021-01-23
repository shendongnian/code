    return ctx
    .Include(s => s.Customer.CustomerType)
    .Select(s => new {
      System = s,
      VRTSystemProductConfigurations = s.VRTSystemProductConfigurations.Where(pc => pc.Active)
    })
    .AsEnumerable() 
    .Select(s => s.System);
