    try
    {
          foreach (string file in Directory.EnumerateFiles(@"C:\", "*.*", SearchOption.AllDirectories))
          {
                FileInfo info = new FileInfo(file);
                if (!(info.Attributes == (FileAttributes.Hidden | FileAttributes.System)))
                {
                    Console.WriteLine(file);
                }
          }
    }
    catch(UnauthorizedAccessException e)
    {
         Console.WriteLine(e.Message);
    }
