    this.loginControl1.Authenticate += delegate(object o, AuthenticateEventArgs ea)
    {
        if(ea.Authenticated)
        {
            return;
        }
        System.Threading.Thread.Sleep(2000);
        ea.Authenticated = false;
    };
    this.loginControl1.Authenticate += delegate(object o, AuthenticateEventArgs ea)
    {        
        if(ea.Authenticated)
        {
            return;
        }
        System.Threading.Thread.Sleep(2000);
        ea.Authenticated = true;
    };
    this.loginControl1.Authenticate += delegate(object o, AuthenticateEventArgs ea)
    {
        if(ea.Authenticated)
        {
            return;
        }
        System.Threading.Thread.Sleep(2000);
        ea.Authenticated = false;
    };
