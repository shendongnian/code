    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRouteLowercase(
            "Customer_default",
            "Customer/{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional }
        );
        context.MapRouteLowercase(
            "MyCustomerHomeDefault",
            "Customer/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
