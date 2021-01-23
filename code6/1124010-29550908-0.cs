        [HttpPost]
        // Remove FormCollection and replace with UserModel.
        public ActionResult Register([Bind(Include= "Username,Password,EmailAddress")] UserModel user)
        {
            if (TryUpdateModel(user))
            {
                // Set password in TryUpdate success.
                user.Password = e.Encrypt(user.Password);; // Set correctly
                context.Entry(user).State = EntityState.Added;
                context.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
