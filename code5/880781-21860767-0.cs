    public List<Data.Item> Get<T>(int id, DateTime createdBeforeDate)
    {
         return this.dbContext.Set<T>().Where(i => i.UserId.Equals(id) &&
                                                   SqlFunctions.DateDiff("DAY", i.Created, createdBeforeDate) > 0))
                                       .ToList();
    }
