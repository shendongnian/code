      int[] a = new int[] 
       { 2, 3, 4, 3, 4, 2, 4, 2, 4 };
    
      // I'd rather not used array, as you suggested, but dictionary 
      Dictionary<int, int> b = a
        .GroupBy(item => item)
        .ToDictionary(item => item.Key, item => item.Count());
    
     ...
    
    the outcome is
      b[2] == 3;
      b[3] == 2;
      b[4] == 4;
       
