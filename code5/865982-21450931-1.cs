    ...
    Boolean isFirstLine = true;
    
    while ((line = sr.ReadLine()) != null) {
      // If line starts with "05" we should print out counter 
      // (that is number of "03" started lines)
      // unless it is the first line in the file
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
    
      // We should also print out counter after the last file line
      // if, say, counter > 0 
      if (sr.Peek() < 0) // <- No next line
        if (counter > 0)
          sw.WriteLine(counter.ToString());
    
      isFirstLine = false;
    }
    ...
