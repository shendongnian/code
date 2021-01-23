    static void RecursiveSearch(string root)
    {
         string[] files = null;
         string[] subDirs = null;
    
         // First, process all the files directly under this folder 
         try
         {
            files = Directory.EnumerateFiles(root).ToArray();
         }
         catch (UnauthorizedAccessException e)
         {
             logger.Add(e.Message);
         }
         catch (System.IO.DirectoryNotFoundException e)
         {
             Console.WriteLine(e.Message);
         }
    
         if (files != null)
         {
                   
              DirectoryTree.Add(new DirectoryInfo(root), files.ToList());
              subDirs = Directory.GetDirectories(root);
    
              foreach (string dir in subDirs)
              {
                  RecursiveSearch(dir);
              }
         }
    }
