    public void UserConfirmation(string email)
    {
        try
        {
        //code to modify user in database
        }
        catch { }
    
        string url = ConfigurationManager.AppSettings["RedirectConfirmationPage"];
        HttpContext.Current.Response.RedirectPermanent(url);
    }
