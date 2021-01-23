    ...
    Boolean isFirstLine = true;
    
    while ((line = sr.ReadLine()) != null) {
      if (line.StartsWith("05")) {
        if (!isFirstLine)
          sw.WriteLine(counter.ToString()); 
       
        sw.WriteLine(line); 
        counter = 0;  
        isFirstLine = false; 
        continue;
      }
    
      sw.WriteLine(line);
    
      if (line.StartsWith("03")) 
        counter += 1;
    
      if (sr.Peek() < 0) // <- No next line
        sw.WriteLine(counter.ToString());
    
      isFirstLine = false;
    }
    ...
