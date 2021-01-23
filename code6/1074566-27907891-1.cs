    static void CheckAndCreateFolder(string p)
    {
           if (!Directory.Exists(p)) {
                  Directory.CreateDirectory(p);
           }
    }
