    string line;
    Dictionary Define<string, int> = new Dictionary<string, int>();
    
    while ((line = reader.ReadLine()) != null)
    {
       if(line.StartsWith(";"))
       {
          continue;
       }
    
       if(line.StartsWith("#define")
       {
          string[] defineItems = line.Split();
          Define[defineItems[1]] = defineItems[2];
          continue;
       }
    
       if(line.StartsWith("[SETTINGS]"))
            {
    
            }
            if(item.StartsWith("[SECTIOn]"))
            {
    
            }
        
    }
