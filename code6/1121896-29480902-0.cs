     public IEnumerable<int> GetNumbers()
     {
      return Enumerable.Range(0,10)
                       .ToList();
     }
    
     public IEnumerable<int> GetNumbers()
     {
      return Enumerable.Range(0,10)
                       .ToArray();
     }
    
     public IEnumerable<int> GetNumbers()
     {
      return Enumerable.Range(0,10);
     }
