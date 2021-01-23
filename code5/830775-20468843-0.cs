    public class Listener
    {
        private static Listener listener = null;  //singleton instance
        
        //member variables
        private HttpListener httpListener = null;
        private int port = -1;
        
        static Listener()
        {
            listener = new Listener();
            // start listener
            try {
                 listener.Start();
             }
             catch { }
        }
        // Use this method in other classes to start listener if it fails
        // in static constructor
        public static Listener Instance { get { return listener; } }
        
        private Listener()
        {
        }
         public bool IsConnected {
             get { return httpListener != null; }
         }
         public void Start() 
         {
            try
            {
                port = //randomly generate
                httpListener = new HttpListener();
                //start listening
            }   
            catch(Exception ex)
            {
                //cant listen on randomly chosen port
            httpListener = null;
                port = -1;
                return;            
            }   
        }
    }
