    try 
    {
       
    }
    catch(Exception ex)
    {
     string userName = "username1";  
     string[] roles = { "" };
     Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), roles);
     ErrorSignal.FromCurrentContext().Raise(ex);
    }
