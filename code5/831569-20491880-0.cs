    List<string> lines = new List<string>();
    
    using (var sr = new StreamReader("filmnames.txt"))
    {
      string line;
      
      while ((line = sr.ReadLine()) != null)
      {
        lines.Add(line);
      }
    }
    
    lines.Sort();
    
    // Or...
    
    lines = lines.OrderBy(i => i).ToList();
    
    // And write the output
    foreach (var line in lines)
    	Console.WriteLine(line);
