            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    if (UserManager.IsInRole(user.Id, "Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (UserManager.IsInRole(user.Id, "Clerk"))
                    {
                        return RedirectToAction("Index","Employee");
                    }
                    else if (UserManager.IsInRole(user.Id, "Customer"))
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                    //return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("","Invalid username or password");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
