    protected void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
    
        if (ex.Message == "File does not exist.")
        {
            throw new Exception(string.Format("{0} {1}", ex.Message, HttpContext.Current.Request.Url.ToString()), ex);
        }
    }
