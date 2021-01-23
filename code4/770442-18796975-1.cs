    public List<SysLog> List(SysLogFilter filter)
    {
        Entities dbContext = DAODbContext.Instance.EntitiesFactory();
        IQueryable<SYSLOG> query = dbContext.SYSLOG;
        if(!String.IsNullOrWhitespace(filter.Attribute1))
             query.Where(s => s.Attribute1 == filter.Attribute1);
        if(!String.IsNullOrWhitespace(filter.Attribute2))
             query.Where(s => s.Attribute2 == filter.Attribute2);
        if(filter.Date != null)
             query.Where(s => s.DATETIME == filter.Date)
        return query.ToList();
     }
