      Dictionary<DateTime, SomeMyType> dict1 = ...
      Dictionary<DateTime, SomeMyType> dict2 = ...
      Boolean hasSameKeys = false;
    
      HashSet<DateTime> hash = new HashSet<DateTime>();
    
      foreach (DateTime key in dict1.Keys)
        hash.Add(new DateTime(key.Year, key.Month, 1));  // <- Ignore Day
    
      foreach (DateTime key in dict2.Keys)
        if (hash.Contains(new DateTime(key.Year, key.Month, 1))) {
          // dict1 contains keys from dict2  
          hasSameKeys = true;
          break;    
        }
