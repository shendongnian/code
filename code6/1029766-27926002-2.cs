        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "myarea_default",
                "{culture}/myarea/{controller}/{action}/{id}",
                new { action = "Index", culture = string.Empty, area = AreaName, id = UrlParameter.Optional }
            );
        }
