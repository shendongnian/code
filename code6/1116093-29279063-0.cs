    context.MapRoute(
        "Admin_Login",
        "Admin/Login/{id}",
        new { controller = "Home", action = "Login", id = UrlParameter.Optional }
    );
    context.MapRoute(
        "Admin_Register",
        "Admin/Register/{id}",
        new { controller = "Home", action = "Register", id = UrlParameter.Optional }
    );
