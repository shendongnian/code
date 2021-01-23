    for (int i = 2; i <= 100; i += 1)
    {
      int toPrint = i
    
      if((i & 1)==1)
      {
        // It's odd
        toPrint = -toPrint;
      }
    
      Console.WriteLine(toPrint);
    }
