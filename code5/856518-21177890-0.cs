    for(int i=0; i < strAllFiles.Length; i++)
    { 
       var file = strAllFiles[i];
       foreach(char c in file)
       {
          if (c > 127)
          {
             using (SqlConnection con = new SqlConnection(CS))
             {
        
               ...
    
             } 
          }
        }
        strAllFiles[i] = file;
    } 
