    public void UserConfirmation(string email)
    {
        //code to modify user in database
    
        string url = ConfigurationManager.AppSettings["RedirectConfirmationPage"];
        HttpContext.Current.Response.RedirectPermanent(url);
    }
