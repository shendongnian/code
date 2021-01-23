    [HttpPost]
    public ActionResult Authorize(Guid eventId)
    {
    	var @event = this.eventRepository.Find(eventId);
    
    	var redirectUri = ConfigurationProvider.HostingEndpoint + this.Url.Action("AuthorizeCallback", new { eventCode = @event.Code });
    
    	var service = new FacebookClient();
    	var loginUrl = service.GetLoginUrl(new {
    		client_id = ConfigurationProvider.FacebookAppId,
    		client_secret = ConfigurationProvider.FacebookAppSecret,
    		redirect_uri = redirectUri,
    		response_type = "code",
    		scope = "manage_pages, publish_actions, user_photos, publish_stream" // Add other permissions as needed
    	});
    
    	return new RedirectResult(loginUrl.AbsoluteUri, permanent: false);
    }
    
    public ActionResult AuthorizeCallback(string code, string eventCode, UserProfile userProfile)
    {
    	var @event = this.eventRepository.Find(eventCode);
    
    	if (string.IsNullOrWhiteSpace(code) == true)
    	{
    		// means user clicked "cancel" when he was prompted to authorize the app
    		// todo: show some error message? or just redirect back?
    		return this.RedirectToAction("Event", "Dashboard", new { eventCode = @event.Code, feature = FeatureType.Update });
    	}
    
    	var redirectUri = ConfigurationProvider.HostingEndpoint + this.Url.Action("AuthorizeCallback", new { eventCode = @event.Code });
    
    	var fb = new FacebookClient();
    	dynamic result = fb.Post("oauth/access_token", new
    	{
    		client_id = ConfigurationProvider.FacebookAppId,
    		client_secret = ConfigurationProvider.FacebookAppSecret,
    		redirect_uri = redirectUri,
    		code = code
    	});
    
    	var accessToken = result.access_token;
    
    	// update the facebook client with the access token so 
    	// we can make requests on behalf of the user
    	fb.AccessToken = accessToken;
    
    	// Get the user's information
    	dynamic me = fb.Get("me");
    
    	return this.RedirectToAction("Event", "Dashboard", new { eventCode = @event.Code, feature = FeatureType.Update });
    }
