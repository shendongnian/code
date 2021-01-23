      List<SomeClass> list = ...
    
      Double sumX = 0.0;
      Double sumXX = 0.0;
    
      foreach (var item in list) {
        Double x = item.SomeProperty;
    
        sumX += x;
        sumXX += x * x;
      }
    
      Double mean = sumX / list.Count;
      Double variance = (sumXX / list.Count - mean);
