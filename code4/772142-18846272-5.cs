    public List<user> CustomFilter(List<filterParm> parms) {
      IQueryable<TEntity> query = _dbSet;
      if (parms.Count > 0 ){
        IQueryable<TEntity> init = _dbSet;
        var firstParm = parms[0];
        query = query.Where(u => u.Age == firstParm.Age && u.Name == firstParm.Name);
        for(int i = 1; i < parms.Count; i++)
        {                    
           var nextParm = parms[i];
           init = init.Where(u => u.Age == nextParm.Age && u.Name == nextParm.Name);
           query = query.Union(init);
        }
      }
      return query.ToList();
    }
