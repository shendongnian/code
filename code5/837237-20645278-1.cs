    // this 1st class calls methods of a 2nd class
    public class Lru_operation
    {
        // create an object of the 2nd class
        // Note that this can be private, since it's only used in this class
        private Lru_Listen lruListen = new Lru_Listen();
        // this method calls two methods from other class   
        public void LruOperation()
        {   
            // No longer required
            // lruListen.ListenForAag();          // first method call
            lruListen.LruListenAccReq();       // second method call 
        }
    }
    // this is the 2nd class 
    public class Lru_Listen
    {
        HttpListener listener;
        // use the constructor
        public Lru_Listen()
        {
            listener = new HttpListener(); 
        }
        public void LruListenAccReq()
        {
            HttpListenerContext context = listener.Getcontext();        
        }
    }  
