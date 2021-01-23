    public ActionResult Index(Models.Login login)
        {
            if (ModelState.IsValid)
            {
                Dal.Login dLogin = new Dal.Login();
                string result = dLogin.LoginUser(login);
                if (result == "Success")
                    Session["AuthState"] = "Authenticated";
            }
            return View();
        }
