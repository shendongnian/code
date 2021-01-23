    private static void OnDeleted(object source, FileSystemEventArgs e)
    {
      bool iSDirectory = Path.GetExtension(e.FullPath).Equals("");
      if(iSDirectory)
       {
            Console.WriteLine("Directory:{0}",e.FullPath);
       }
       else
       {
             Console.WriteLine("File:{0}",e.FullPath);
       }
    }
