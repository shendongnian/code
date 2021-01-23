    [HttpPost]
    public ActionResult InsertRssFeed(string Name, string Url)
    {
    
        if (String.IsNullOrEmpty(Name.Trim()) || String.IsNullOrEmpty(Url.Trim()))
        {
            ModelState.AddModelError("", "Name and URL are required fields.");
    		return View();
        }
    	
    	var rssFeed = new RssFeed();
            rssFeed.Name = Name;
            rssFeed.Url = Url;
    
    	using (AuthenticationManager authenticationManager = new AuthenticationManager(User))
    	{
    		string userSid = authenticationManager.GetUserClaim(SystemClaims.ClaimTypes.PrimarySid);
    		string userUPN = authenticationManager.GetUserClaim(SystemClaims.ClaimTypes.Upn);
    
    		rssFeedService.CreateRssFeed(rssFeed);
    	}
    
        return RedirectToAction("ReadAllRssFeeds", "Rss");
    }
