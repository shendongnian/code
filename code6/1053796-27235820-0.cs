    System.IO.StreamReader file = 
       new System.IO.StreamReader("Your txt file");
    Dictionary<string, string> values = new Dictionary<string, string>();
    string keyContainer = "";
    
    while((line = file.ReadLine()) != null)
    {
       if(line.Trim() == "")
          continue;
       
       if(values.Keys.Contains(line.Trin())
          continue;   
    
       if(line.StartsWith('[') && line.EndsWith("]")
       {
           keyContainer = line.Trim();
           values.Add(line.Trim(), "");
       }
       else
       {
           values[keyContainer] = line.Trim();    
       }
    }
