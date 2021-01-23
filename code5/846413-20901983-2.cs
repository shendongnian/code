    public IEnumerable GetJames(int page = 1, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,)
    { 
          var query = repository.James;
           //other stuff
          if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
         
    }
