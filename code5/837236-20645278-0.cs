    // Make an instance variable:
    HttpListener listener;
    // 1st method creates an object from a different class (HttpListener)
    public void ListenForAag()
    {
        // Set the instance variable
        listener = new HttpListener(); 
    }
    // 2nd method calls 1st method's object to perform 
    // a method task from a different class
    public void LruListenAccReq()
    {
        HttpListenerContext context = listener.Getcontext();        
    }
