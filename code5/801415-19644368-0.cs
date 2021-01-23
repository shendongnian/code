    static class ConfigurationDetails {
      private static string[] cores = new string[5];
      public static string Server { // = iic-belfort
         get { return cores[0];}
         set { cores[0] = value;}
      }
      public static string username { // = administrator
         get { return cores[1];}
         set { cores[1] = value;}
      }
      public static string password { //= GARBLED
         get { return cores[2];}
         set { cores[2] = value;}
      }
      public static string folder { //= iicservices
         get { return cores[3];}
         set { cores[3] = value;}
      }
      public static string sqlserver { //=127.8.9.1   
         get { return cores[4];}
         set { cores[4] = value;}
      }
      public static void Init(string[] coreData) {
         cores = coreData;
      }
    }
    //Then do something like this:
    var c = File.ReadAllLines(@"C:\Config.txt")
                .Select(line=>line.Split('=')[1].Trim()).ToArray();
    ConfigurationDetails.Init(c);
