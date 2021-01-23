    [HttpPost]
    public ActionResult Index(Users users)
    {
            if (ModelState.IsValid)
            {
                var authUser = db.Users.FirstOrDefault(row => row.userName == users.userName && row.userPassword == users.userPassword )
                if ( authUser != null )
                {
                    Session["role"] = authUser.Role;
                    FormsAuthentication.SetAuthCookie(users.userName, false);
                    return RedirectToAction("", "Home");
                }
                else 
                {
                    ModelState.AddModelError("", "Invalid username and/or password");
                }
            }
            return View();
    }
