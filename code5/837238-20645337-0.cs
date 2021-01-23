    public class Lru_Listen
    {
     HttpListener listener;
    // 1st method creates an object from a different class (HttpListener)
    public void ListenForAag()
    {
        listener = new HttpListener(); 
    }
    // 2nd method calls 1st method's object to perform 
    // a method task from a different class
    public void LruListenAccReq()
    {
        HttpListenerContext context = listener.Getcontext();        
    }
    }  
