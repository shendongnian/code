    /// This function is used to delete all files inside a folder 
     public static void CleanFiles()
     {
            if (Directory.Exists("FOLDER_PATH"))
            {
                var directory = new DirectoryInfo("FOLDER_PATH");
               foreach (FileInfo file in directory.GetFiles())
               { 
                  if(!IsFileLocked(file)) file.Delete(); 
               }
            }
     }
