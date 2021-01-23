    protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            // Clear the error
            Server.ClearError();
            // Log exception
        }
