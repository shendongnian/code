    public static IAppBuilder UseScopePerOwinRequest(this IAppBuilder builder,IDependencyResolver resolver)
            {
                builder.Use(async (context, next) =>
                {
                    using (var instance = resolver.BeginScope())
                    {
                        context.Set<IDependencyScope>(instance);
                        if (next != null)
                        {
                            await next();
                        }
                    }
    
                });
    
                return builder;
            }
