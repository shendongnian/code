    public IEnumerable<T> GetKittens<T>(Expression<Func<Kitten, bool>> predicate = null, int take = -1, int skip = -1) where T : KittenViewModel, new()
    {
    
      var kittenModels = GetModels(); // IQueryable<T>
    
      if(skip > 0)
        kittenModels = kittenModels.Skip(skip);
    
      if(take > 0)
        kittenModels = kittenModels.Take(take);
    
      kittenModels = kittenModels.Where(predicate); 
    
    }
