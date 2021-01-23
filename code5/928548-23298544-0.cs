    public class FirewallJoin
    {
         private string _consoleServerPort;
         public string ConsoleServerPort
         {
             get
             {
                   return _consoleServerPort;
             }
             set
             {
                 _consoleServerPort = value.Trim();
             }
         }
    }
