        public ActionResult Index()
        {
            using (UserInfoContext.Create(myUserInfo))
            {
                // do stuff that calls your repositories
                return View();
            }
        }
