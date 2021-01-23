		public AccountController()
		{
			HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
		}
		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(Account model)
		{
			if (ModelState.IsValid)
			{
				return PartialView("Thanks");
			}
			return PartialView("Index");
		}
    }
