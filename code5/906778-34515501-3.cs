    public ActionResult Index()
         {
                 //DOES NOT WORK - When used the error "Invalid token." will always trigger.
                 var provider = new DpapiDataProtectionProvider("ApplicationName");
                 var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                 userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("ASP.NET Identity"));
                 var user = userManager.FindByName("useremail@gmail.com");
                 string code = userManager.GeneratePasswordResetToken(user.Id);
                 var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                 //DOES NOT WORK - When used the error "Invalid token." will always trigger.
             return View();
         }
