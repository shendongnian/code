    using (var db = new EFDbContext())
    {
        var results = d.ServiceStatusHistory.Where( => h.Service.Enabled)
                                            .OrderByDescending(h => h.time )
                                            .GroupBy(h => h.Service.Id)
                                            .Select(grp => grp.FirstOrDefault()); 
    }
