    public ActionResult Login(LoginViewModel viewModel)
        {
            string returnUrl = (string)TempData["ReturnUrl"];           
            if (ModelState.IsValid)
            {
                if (viewModel.IsLoggedIn(repository))
                {
                    if (String.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");
                    else return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("Email", "");
                    ModelState.AddModelError("Password", "");
                }
            }
            return View(viewModel);
        }
