    private static void AuthenticateAllRequests(IAppBuilder app, params string[] authenticationTypes)
    {
        app.Use((context, continuation) =>
        {
            if (context.Authentication.User != null &&
                context.Authentication.User.Identity != null &&
                context.Authentication.User.Identity.IsAuthenticated)
            {
                return continuation();
            }
            else
            {
                context.Authentication.Challenge(authenticationTypes);
                return Task.Delay(0);
            }
        });
    }
