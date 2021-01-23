     public List<int> GetNumbers()
     {
      // Compile error as int[] and List<int> are different types
      return Enumerable.Range(0,10)
                       .ToArray(); 
     }
     public int[] GetNumbers()
     {
      // Compile error as int[] and List<int> are different types
      return Enumerable.Range(0,10)
                       .ToList(); 
     }
