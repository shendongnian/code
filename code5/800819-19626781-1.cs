    if (s.Contains(":"))
    {
      string[] x = s.Split(':');
      string out = x[x.Length-1];
      System.Console.Write(out);
    }
    else
      System.Console.Write(": not found"); 
   
    
