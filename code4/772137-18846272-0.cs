    public List<user> CustomFilter(List<filterParm> parms) {
      IQueryable<TEntity> query = new List<TEntity>{};
      if (parms.Count > 0 ){
        IQueryable<TEntity> init = _dbSet;
        
        foreach (var parm in parms)
        {                    
           init = init.Where(u => u.Age == parm.Age && u.Name == parm.Name);
           query = query.Concat(init);
        }
      }
      return query.ToList();
    }
