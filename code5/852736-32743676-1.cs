        public ActionResult Index()
        {
            if (MyNamespace.External.FreeAgent.AuthToken == "")
            {
                return Redirect("https://api.freeagent.com/v2/approve_app?redirect_uri=" + Request.Url.Scheme + "://" + Request.Url.Authority + "/Invoice/Auth" + "&response_type=code&client_id=obboj7WPe1LhMCGcR87xXQ");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Auth()
        {
            if (Request.Params.Get("code").ToString() != "")
            {
                ClientZone.External.FreeAgent.AuthToken = Request.Params.Get("code").ToString();
            }
            return View("Index");
        }
