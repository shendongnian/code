    public ActionResult CompleteFacebookAuth(string code)
    {
        var fb = new FacebookClient(code);
        dynamic result = fb.Get("me");
    }
