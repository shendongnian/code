    public override bool ValidateUser(string username, string password)
    {
       string ipAddress = HttpContext.Current.Request.UserHostAddress;
       string browser = HttpContext.Current.Request.Browser.Version;
       
       // Do something
    }
