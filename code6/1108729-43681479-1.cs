        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Default",
                "Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });
            context.MapRoute(
                "Help Area",
                "",
                new { controller = "Help", action = "Index" });
            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
