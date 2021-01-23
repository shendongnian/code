       public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Authentication_Account",
                "Authentication/SignIn",
                new
                { 
                    controller = "Account",
                    action = "SignIn",
                    id = UrlParameter.Optional
                },
                new[] { "MyApp.Areas.Authentication.Controllers" });
        }
     
