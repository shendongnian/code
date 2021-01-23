            app.Use(async (context, next) =>
            {
                var user = context.Authentication.User;
                if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
                {
                    context.Authentication.Challenge();
                    return;
                }
                await next();
            });
