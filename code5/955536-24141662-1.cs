      Dictionary<String, String[]> data = new Dictionary<String, String[]>();
    
      String key = null;
      List<String> values = new List<String>();
    
      foreach (String line in File.ReadLines(path)) {
        // Skip blank lines
        if (String.IsNullOrEmpty(line))
          continue; 
        // Check if it's a key (that should start from digit)
        if ((line[0] >= '0' && line[0] <= '9')) { // <- Or use regular expression
          if (!Object.ReferenceEquals(null, key))
            data.Add(key, values.ToArray());
    
            key = line;
            values.Clear();
    
            continue;
        }
        // it's a value (not a blank line and not a key)
        values.Add(line);
      }
    
      if (!Object.ReferenceEquals(null, key))
        data.Add(key, values.ToArray());
