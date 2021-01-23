    public class CheckAndCreateFolder(string p)
    {
           if (!Directory.Exists(p)) {
                  Directory.CreateDirectory(p);
           }
    }
