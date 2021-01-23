    const int LineCharacterLimit = 4;
    int i = 0;    
    foreach (int i in List)
    {
       i++;
       if (i == LineCharacterLimit)
       {
          Console.WriteLine("{0}", i);
          i=0;
       }
       else 
       {
          Console.Write("{0}", i);
       } 
    }
