    public static bool CopyFile(string source, string destination)
    {
         if(!File.Exist(source))
              return false;
    
         if(string.IsNullOrEmpty(destination))
              return false;
         try
         {
              using(var reader = File.Open(source))
                   using(var writer = File.Create(destination))
                        reader.CopyTo(writer);
    
              return true;
         }
         
         catch(IOException ex) { return false; }
    }
