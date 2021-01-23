                case SignInStatus.Success:
                    // Require the user to have a confirmed email before they can log on.
                    var user = await UserManager.FindByNameAsync(model.Email);
                    if (user != null)
                    {
                        if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                        {                                                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                            ViewBag.errorMessage = "You must have a confirmed email to log on.";
                            return View("DisplayEmail");
                        }
                    }
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
