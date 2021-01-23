      Dictionary<String, String[]> data = new Dictionary<String, String[]>();
    
      String key = null;
      List<String> values = new List<String>();
    
      foreach (String line in File.ReadLines(path)) {
        if (!String.IsNullOrEmpty(line))
          if ((line[0] >= '0' && line[0] <= '9')) { // <- Or use regular expression
            if (!Object.ReferenceEquals(null, key))
              data.Add(key, values.ToArray());
    
            key = line;
            values.Clear();
    
            continue;
          }
        
        values.Add(line);
      }
    
      if (!Object.ReferenceEquals(null, key))
        data.Add(key, values.ToArray());
