    public IEnumerable GetJames(int page = 1, IOrderedQueryable<TEntity>> orderBy = null,)
    { 
          var query = repository.James;
           //other stuff
          if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
         
    }
