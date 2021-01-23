      random gen = new Random();
    
      Dictionary<int, Double> dict = new Dictionary<int, Double>();
    
      // In general it'll take about 
      // 2 * sqrt(2^32) = 2 * 65536 = 131072 = 1e5 itterations
      // to find out a hash collision (two unequal values with the same hash)  
      while (true) {
        Double d = gen.NextDouble();
        int key = d.GetHashCode();
    
        if (dict.ContainsKey(key)) {
          Console.Write(d.ToString(Culture.InvariantCulture));
          Console.Write(".GetHashCode() == ");
    
          Console.Write(dict[key].ToString(Culture.InvariantCulture));
          Console.Write(".GetHashCode() == ");
          Console.Write(key.ToString(Culture.InvariantCulture));
    
          break;
        }
    
        dict.Add(key, d);
       }
