    public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            try
            {
                User user = accountDal.GetAllUsers().FirstOrDefault(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Response.Redirect(returnUrl, false);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        return View(loginViewModel);
    }
