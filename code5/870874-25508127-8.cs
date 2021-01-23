    [HttpPost]
    public ActionResult Index(IndexViewModel model)
    {
        if (ModelState.IsValid)
        {
            var myConfig = new ClientConfigurationContainer
            {
                ClientCode = null,
                ClientId = model.ClientId,
                ClientSecret = model.ClientSecret,
                RedirectUri = Request.Url.AbsoluteUri + Url.Action("AuthCode")
            };
            var myYammer = new YammerClient(myConfig);
            // Obtain the URL of Yammer Authorisation Page
            var url = myYammer.GetLoginLinkUri();
            this.TempData["YammerConfig"] = myConfig;
            // Jump to the url page
            return Redirect(url);
        }
        return View(model);
    }
 
