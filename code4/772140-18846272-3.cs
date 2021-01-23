    //I'm not very familiar with EF, not sure if this can be translated into SQL by EF
    //Hope you give it a test (I also want to know the result :)
    public List<user> CustomFilter(List<filterParm> parms) {
      IQueryable<TEntity> query = _dbSet;
      if(parms.Count > 0){
        query = query.Where(u=>parms.Any(p=>p.Age == u.Age && p.Name == u.Name));
      }
      return query;
    }
