    bool AuthenticationMethod1(object o, AuthenticateEventArgs ea)
    {
        System.Threading.Thread.Sleep(2000); //Simulate some long running task.
        return false; //Return true or false based on authentication failed or succeeded.
    }
    bool AuthenticationMethod2(object o, AuthenticateEventArgs ea)
    {
        System.Threading.Thread.Sleep(2000); //Simulate some long running task.
        return true; //Return true or false based on authentication failed or succeeded.
    }
    bool AuthenticationMethod3(object o, AuthenticateEventArgs ea)
    {
        System.Threading.Thread.Sleep(2000); //Simulate some long running task.
        return false; //Return true or false based on authentication failed or succeeded.
    }
