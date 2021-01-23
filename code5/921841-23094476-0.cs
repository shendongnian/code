            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {UserName = model.UserName};
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var newUser = db.ApplicationUsers.Find(user.Id);
                    var profile = new Profile
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Identity = newUser,
                    };
                    db.Profiles.Add(profile);
                    db.SaveChanges();
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }
