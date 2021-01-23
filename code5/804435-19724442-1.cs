    foreach( StreamReader SR in FileList)
    {
      if(SR == null) continue;
 
      while (!SR.EndOfStream)
      {
          Content = SR.ReadLine() ; 
          if(Content != null && Content.Contains(Name))
          {
           Console.WriteLine("Found");
          }
       }
     } 
