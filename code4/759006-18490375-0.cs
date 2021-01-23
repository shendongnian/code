       public class Log
       {
          public static void WriteLine(string errorMsg)
          {
             string err = DateTime.Now.ToString("dd/MM/yyyy hh:mm") + " - " + errorMsg;
    
             if (File.Exists("@d:\log.txt") == false)
             {
                File.Create("@d:\log.txt");
             }
    
             using(StreamWriter writer = new StreamWriter("@d:\log.txt", true))
             {
                writer.WriteLine(err);
             }
          }
       }
