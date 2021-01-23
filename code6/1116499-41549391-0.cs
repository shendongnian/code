    public async Task<ActionResult> ChangePassword(ResetPasswordViewModel CP)
    {
         ApplicationDbContext context = new ApplicationDbContext();
         UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
         UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
         var user = await UserManager.FindAsync(User.Identity.Name, CP.CurrentPassword);
        
         if (!UserManager.CheckPassword(user, CP.CurrentPassword))
         {
               ViewBag.notification = "Incorrect password.";
               return View("~/Views/User/settings.cshtml");
         }
         else
         {
               if (CP.Password != CP.ConfirmPassword)
               {
                     ViewBag.notification = "try again";
                     return View("~/Views/User/settings.cshtml");
               }
               else
               {
                     String hashedNewPassword = UserManager.PasswordHasher.HashPassword(CP.Password);
                     await store.SetPasswordHashAsync(user, hashedNewPassword);
                     await store.UpdateAsync(user);
                     ViewBag.notification = "successful";
                     return View("~/Views/User/settings.cshtml");
                }
          }
     }
