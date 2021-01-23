    private static void RegisterCurrentContext(ContainerBuilder builder)
    {
        // Register current context
        builder.Register(c =>
        {
            // Try to get User's Id first from Identity of HttpContext.Current
            var appUserId = HttpContext.Current.User.Identity.GetUserId<int>();
            // If appUserId is still zero, try to get it from Owin.Enviroment where WebApiAuthInfo middleware components puts it.
            if (appUserId <= 0)
            {
                object appUserIdObj;
                var env = HttpContext.Current.GetOwinContext().Environment;
                if (env.TryGetValue(MyWebApp.Constants.Constant.WebApiCurrentUserId, out appUserIdObj))
                {
                    appUserId = (int)appUserIdObj;
                }
            }
            // WORK: Read user from database based on appUserId and create appUser object.
            return new DefaultCurrentContext
            {
                CurrentUser = appUser,
            };
        }).As<ICurrentContext>().InstancePerLifetimeScope();
    }
