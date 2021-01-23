    [HttpPost]
    public ActionResult Index(Users users)
    {
            if (ModelState.IsValid)
            {
                if ( db.Users.Any(row => row.userName == users.userName && row.userPassword == users.userPassword ) )
                {
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
