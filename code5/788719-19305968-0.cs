     public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("About", "About", "~/About.aspx", true);
            routes.MapPageRoute("Add User", "Add User", "~/Add.aspx", true);
            routes.MapPageRoute("Login", "Login", "~/Login.aspx", true);
            routes.MapPageRoute("Map", "Map", "~/Map.aspx", true);
            routes.MapPageRoute("Register", "Register", "~/Register.aspx", true);
            routes.MapPageRoute(
                                           "ViewList",
                                           "ViewList/{c}/{s}", 
                                           "~/ViewList.aspx", 
                                           true
                                         );
            routes.MapPageRoute(
                                           "ViewUser",
                                           "ViewUser/{id}",
                                           "~/ViewUser.aspx",
                                           true
                                         );
            routes.MapPageRoute(
                                         "MyAccount",
                                         "MyAccount/{id}",
                                         "~/MyAccount.aspx",
                                         true
                                       );
        }
