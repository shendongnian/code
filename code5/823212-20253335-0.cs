    IDbCommand cmd = proxy.Connection.CreateCommand();
    
    try
    {    
        //...
    }
    finally
    {
        if(cmd != null)
            ((IDisposable)cmd).Dispose();
    }
