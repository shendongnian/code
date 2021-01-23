    var name = getNameFromService();
    
    var current = _dbContext.Names.Find(name.BusinessSystemId, name.NameNo);
    if (current == null)
    {
        _dbContext.Names.Add(name);
    }
    else
    {
        _dbContext.Entry(current).CurrentValues.SetValues(name);
    }
    _dbContext.SaveChanges();
