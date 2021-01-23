    public ActionResult UserClicksAuthenticate()
    {
    	var redirectUri = Request.Url.Authority + this.Url.Action("AuthorizeCallback", new {userCode = "userCode"});
        var sharpSquare = new SharpSquare(clientId, clientSecret);
    	var authUrl = sharpSquare.GetAuthenticateUrl(redirectUri);
    
    	return new RedirectResult(authUrl, permanent: false);
    }
    
    public ActionResult AuthorizeCallback(string code, string userCode)
    {
    	var redirectUri = Request.Url.Authority + this.Url.Action("AuthorizeCallback", new { userCode = userCode });
        var sharpSquare = new SharpSquare(clientId, clientSecret);    
    	var accessToken = sharpSquare.GetAccessToken(redirectUri, code);
        // need this in order to make calls to API
        // it's redundant because token is already set in GetAccessToken() call but it helps to understand the workflow better. 
        sharpSquare.SetAccessToken(accessToken);
        List<VenueHistory> venues = sharpSquare.GetUserVenueHistory();
    
    	return View("Index");
    }
    public ActionResult GetVenues()
    {
        var sharpSquare = new SharpSquare(clientId, clientSecret, appToken);    
        List<VenueHistory> venues = sharpSquare.GetUserVenueHistory();
    
    	return View("Index");
    }
