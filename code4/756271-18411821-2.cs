    public class Connection : IDisposable  // <== Inherit from IDisposable interface
    {
        public const int Port = 50000;// Can be any range between 49152 and 65536
        private SomeType webserv; // Use whatever real type is appropriate here.
        private Information information = new Information();  // or whatever
    
        // This is a real constructor.
        public Connection()
        {
            //SetInformation
            information.Id = 545;
            
            webServ = new ClientSDKSoapClient("ClientSDKSoap"))
            webserv.ContinueConnection.WaitOne();
            webServ.ClientLogin(information);
        }
        
        // Implement IDisposable interface
        public void Dispose()
        {
            webServ.ClientLogout(information);
        }
    }
