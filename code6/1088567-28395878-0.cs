    bool checkFileExists(string file)
    {
     if (!System.IO.File.Exists(file))
     {
        using (FileStream fs = File.Create(file))
        {
           // File created.
           return true;
        }
     }
     else
     {
           if (File.GetCreationTime(file) < DateTime.Now.AddMonths(-1))
              File.Delete(file);
     }
     // File exists.
     return true;
    }
