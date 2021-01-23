    [HttpGet]
        [ActionName("Index")]
        public ActionResult Index_Get()
        {
           return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post(User user, IUser iuser, string Create)
        {
            if (Create == "Login")
            {
                if (ModelState.IsValid)
                {
                    TryUpdateModel(iuser);
                    UserContext userContext = new UserContext();
                    User iusr = userContext.users.Single(usr1 => usr1.EmailId == iuser.EmailId);
                    return RedirectToAction("Success", iusr);
                }
                return View();
            }
            if (Create == "Register")
            {
                if (ModelState.IsValid)
                {
                    UserContext userContext = new UserContext();
                    userContext.users.Add(user);
                    userContext.SaveChanges();
                    return RedirectToAction("Show_Users");
                }
                return View();
            }
            return View();
        }
        [HttpGet]
        [ActionName("Success")]
        public string Success(User iusr)
        {
            return "Welcome "+ iusr.Name;
        }
