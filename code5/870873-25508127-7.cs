    public ActionResult AuthCode(String code)
    {
        if (!String.IsNullOrWhiteSpace(code))
        {
            var myConfig = this.TempData["YammerConfig"] as ClientConfigurationContainer;
            myConfig.ClientCode = code;
            var myYammer = new YammerClient(myConfig);
            // var yammerToken = myYammer.GetToken();
            // var l = myYammer.GetUsers();
            // var t= myYammer.GetImpersonateTokens();
            // var i = myYammer.SendInvitation("test@test.fr");
            // var m = myYammer.PostMessage("A test from here", 0, "Event");
            return View(myYammer.GetUserInfo());
        }
        return null;
    }
