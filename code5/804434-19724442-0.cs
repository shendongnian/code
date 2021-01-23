    foreach( StreamReader SR in FileList)
    {
      while (!SR.EndOfStream)
      {
          Content = SR.ReadLine() ; 
          if(Content != null && Content.Contains(Name))
          {
           Console.WriteLine("Found");
          }
       }
     } 
