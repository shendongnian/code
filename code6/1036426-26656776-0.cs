    public override void RegisterArea(AreaRegistrationContext context)
      {
        context.MapRoute(
            "UserAdmin_default",
            "UserAdmin/{controller}/{action}/{id}",
            new { controller="Menu" action = "MenuPermissions", id = UrlParameter.Optional }                
        );
      }
