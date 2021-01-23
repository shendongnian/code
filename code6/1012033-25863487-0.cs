    public class AsynchronousClient
    {
        // The port number for the remote device.
        private int port = 8888;
        public int Port 
        { 
            get { return port; } 
            set { port = value;}
        }
        // The IP Address of the remote device
        private string ipAddress;
        public string IpAddress
        {
            get { return ipAddress; } 
            set { ipAddress= value;}         
        }
        ....  
    }
