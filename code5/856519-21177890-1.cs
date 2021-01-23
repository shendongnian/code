    for(int i=0; i < strAllFiles.Count; i++) 
    {     
        var file = strAllFiles[i];    
        var newFileValue = file;    
        foreach(char c in file) 
        {
          if (c > 127)
          {
             using (SqlConnection con = new SqlConnection(CS))
             {
        
               ...
               // modify newFileValue
               newFileValue = file2;
    
             } 
          }
        }
        // Modify collection
        strAllFiles[i] = newFileValue; 
    }
