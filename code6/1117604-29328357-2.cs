    public class Config {
      private static Config s_Config;
   
      public static Config Instance {
        get {
          if (s_Config == null)
          {
            // fetch members
            string con = "";
            bool isProduction = false;
            string fileLogPath = "";
            s_Config = new Config(con, isProduction, fileLogPath);
          }
          return s_Config;
        }
      }
      private Config(string con, bool isProduction, string fileLogPath)
      {
        Con = con; 
        IsProduction = isProduction;
        FileLogPath = fileLogPath;
      }
      public string Con { get; private set; }
      public bool IsProduction { get; private set; }
      public string FileLogPath { get; private set; }
    }
