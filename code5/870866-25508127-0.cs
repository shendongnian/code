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
                var url = myYammer.GetLoginLinkUri(); // <== Obtain the URL of Yammer Authorisation Page
                this.TempData["YammerConfig"] = myConfig;
                return Redirect(url); // <= Jump to this page
            }
            return View(model);
        }
 
