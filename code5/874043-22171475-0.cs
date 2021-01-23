        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = MyViewModels.checkUser(model.UserName, model.Password);
                if (user!=null)
                {
                    SignInAsync();
                    return RedirectToAction("Welcome");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }
        private void SignInAsync()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "UserName"));
            claims.Add(new Claim(ClaimTypes.Email, "User@mail.com"));
            var id = new ClaimsIdentity(claims,
                                        DefaultAuthenticationTypes.ApplicationCookie);
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(id);
        }
        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }
