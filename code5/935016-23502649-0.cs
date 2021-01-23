    public static int[] IndicesOf(this string self, char match)
    {
      if (string.IsNullOrEmpty(self))
        return new int[0];
    
      var indices = new List<int>();
    
      for (var i = 0; i < self.Length; i++)
      {
        if (self[i] == match)
          indices.Add(i);
      }
    
      return indices.ToArray();
    }
