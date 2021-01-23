    string[] splitted = str.Split("},{");
    
    
    for(int i = 0; i < splitted.Count ; i++)
    {
      if(i != 0)
      {
         Console.WriteLine("{");
      }
      Console.WriteLine(curr[i]);
      if(i != splitted.Count - 1)
      {
          Console.WriteLine("}");
      }
    }
