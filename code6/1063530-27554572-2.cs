    public void MoveDown(int id)
    {
      var entity = _dbSet.Find(id);
      var nextTwo = _dbSet.Where(x => x.Rank > entity.Rank)
                        .OrderBy(x => x.Rank)
                        .Select(x => x.Rank)
                        .Take(2).ToList();
    
      if (nextTwo.Count == 2)
      {
         entity.Rank = (nextTwo[0] + nextTwo[1]) / 2; 
      }
      // if entity is second last
      else if (nextTwo.Count == 1)
      {
         entity.Rank = nextTwo[0] + 1; 
      }
      
      _context.SaveChanges();
    }
