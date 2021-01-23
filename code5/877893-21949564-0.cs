    protected void Application_Error(object sender, EventArgs e)
    {
        var error = Server.GetLastError();
        string message = error.Message;
        string callStack = error.StackTrace();  
        //Write message and callStack to file
        ...
    }
