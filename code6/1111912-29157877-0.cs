    public ActionResult CompleteFacebookAuth(string code)
    {
        var fb = new FacebookClient(token);
        dynamic result = fb.Get("me");
    }
