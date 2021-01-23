    public static bool ValidateIOPermission(string path)
    {
         try
         {
              if(Directory.Exist(path))
                   return true;
         
              else { Directory.CreateDirectory(path); }
         }
         
         catch(Exception ex) { return false; }
    }
                  
