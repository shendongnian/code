    // Search All Files **Recursive**
    DirSearch(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
    files.Dump();
    
    // Search Files in ProgramFiles Folder Only
    files.AddRange(Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)));
    files.AddRange(Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)));
    
    static List<string> files = new List<string>();
    static void DirSearch(string sDir)
    {
      try
      {
          foreach (string d in Directory.GetDirectories(sDir))
          {
              foreach (string f in Directory.GetFiles(d))
              {
                  if (true /*logic*/)
                      files.Add(f);
              }
              DirSearch(d);
          }
      }
      catch (System.Exception excpt)
      {
          Console.WriteLine(excpt.Message);
      }
    }
