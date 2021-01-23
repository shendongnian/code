                var model = register ?? new RegisterModel();
                if (!WebSecurity.UserExists(model.UserName))
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                }
                if (Roles.RoleExists(role))
                {
                    Roles.AddUserToRole(model.UserName, role);
                }
                else ModelState.AddModelError("NoRole", "Please select a role.");
                var roles = Roles.GetAllRoles().ToList();
                ViewBag.DeliveryArea = new SelectList(roles.Select(x => new { Value = x, Text = x }), "Value", "Text");
                return View();
            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError("", AccountController.ErrorCodeToString(e.StatusCode));
            }
            return View();
