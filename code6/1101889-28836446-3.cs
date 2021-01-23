    private void AcceptCnxCallback(IAsyncResult iar)
    {
    
        MensajeRecibido msj = new MensajeRecibido();
    
        Socket server = (Socket)iar.AsyncState;
        msj.workSocket = server.EndAccept(iar);
    
    //call again the listener after you get a message
    listener.BeginAccept(new AsyncCallback(AcceptCnxCallback), listener);
    }
 
