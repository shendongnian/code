    void Callback(IAsyncResult ar)
    {
        Authenticate d = (Authenticate)ar.AsyncState;
        if (d.EndInvoke(ar))
        {
           OnLoggedIn(new EventArgs());
        }
        else
        {
           OnLoggedError(new EventArgs());
        }
    }
