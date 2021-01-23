        [AuthorizationFilter]
        public ActionResult Index()
        {
            model.Authorized = (bool)HttpContext.Session["authorized"];
            return View(model);
        }
