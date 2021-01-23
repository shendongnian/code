    public static IAppBuilder CreatePerRequest<T>(this IAppBuilder builder )where T:IDisposable
            {
                builder.Use(async (context, next) =>
                {
                    var resolver = context.Get<IDependencyScope>();
    
                    using (var instance = (T) resolver.GetService(typeof (T)))
                    {
                        context.Set<T>(instance);
                        if (next != null)
                        {
                            await next();
                        }
                    }
    
                });
    
                return builder;
            }
