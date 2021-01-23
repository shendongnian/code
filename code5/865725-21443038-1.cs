    void BeginOpenReadCallback(IAsyncResult ar) 
    {
        StateHolder state = ar.AsyncState as StateHolder;
        FtpClient conn = state.client;
    
        //... Everything else the same in the function.
    
        //Context could be null if the Begin was not called from the UI thread.
        if(state.Context != null)
        {
            state.Context.Post(OnCompleted, conn);
        }
        else
        {
             OnCompleted(conn);
        }
    }
    protected virtual void OnCompleted(object state) //I use object instead of FtpClient to make the "state.Context.Post(OnCompleted, conn);" call simpler.
    {
        var conn = state as FtpClient;
        var tmp = Completed; //This is the event people subscribed to.
        (tmp != null)
        {
            tmp(this, new CompletedArgs(conn)); //Assumes you followed the standard Event pattern and created the necessary classes.
        }
    }
