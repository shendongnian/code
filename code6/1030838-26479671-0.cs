    if(role == role1)
    {
        routes.MapRoute(
            "XYZRoute",                                              // Route name
            "XYZ/{action}",                          
            new { controller = "Role1XYZ", action = "Request", id = UrlParameter.Optional }  
        );
    }
