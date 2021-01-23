    public class Connection : IDisposable
    {
        public const int Port = 50000;// Can be any range between 49152 and 65536
        // Use whatever real type is appropriate here.
        private SomeType Webserv;
        private Information information = new Information();  // or whatever
    
        // This is a real constructor.
        public Connection()
        {
            //SetInformation
            information.Id = 545;
            
            WebServ = new ClientSDKSoapClient("ClientSDKSoap"))
            Webserv.ContinueConnection.WaitOne();
            WebServ.ClientLogin(information);
        }
        
        // Implement IDisposable interface
        public void Dispose()
        {
            WebServ.ClientLogout(information);
        }
    }
