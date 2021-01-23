    public class Program
    {
      static void Main(string[] args)
      {
        var locationConfig = (LocationConfig)ConfigurationManager.GetSection("locationConfig");
        foreach (FolderElement folder in locationConfig.Folders)
        {
          // List all folders
          Console.WriteLine(folder.Environment);        
        }    
        // The first folder using indexer property
        Console.WriteLine(locationConfig.Folders[0].Environment);
      }
    }
