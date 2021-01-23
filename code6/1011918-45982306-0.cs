           protected void Application_Error(object sender_, CommandEventArgs e_)
        {
            Exception exception = Server.GetLastError();
            if(exception is CryptographicException)
            {
                FormsAuthentication.SignOut();
            }
        }
