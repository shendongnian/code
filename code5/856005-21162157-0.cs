      List<String> parts = new List<String>();
      StringBuilder part = new StringBuilder();
    
      foreach(Char ch in separatedLine) 
        // Put all possible separators into condition
        if ((ch == ' ') || (ch == ',') || (ch == ';')) {
          parts.Add(part);
          parts.Length = 0;
        }
        else 
          part.Add(ch);  
    
      parts.Add(part); // <- Do not forget to add the last one   
    
      StringBuilder result = new StringBuilder();
    
      for (int i = parts.Count - 1; i >= 0; --i) {
        if (i < parts.Count - 1)
          result.Add(','); // <- Separator to use
    
        result.Add(parts[i]);
      }
      
      return result.ToString();
