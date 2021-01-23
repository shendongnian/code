    String pattern = @"[\x20-\xFF]";
    
    // All ANSII 
    for (Char ch = ' '; ch <= 255; ++ch)
      if (!Regex.IsMatch(ch.ToString(), pattern)) 
        Console.Write("Failed!");
    
    // All non-ANSII
    for (Char ch = (Char)256; ch < Char.MaxValue; ++ch)
      if (Regex.IsMatch(ch.ToString(), pattern)) 
        Console.Write("Failed!");
