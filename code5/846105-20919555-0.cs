            builder.RegisterType<Data.Model.DataContext>()
                .As<IDataContext>()
                .InstancePerHttpRequest();
            // Added this here to ensure the context passed in is my DataContext
            builder.RegisterType<UserStore<ApplicationUser>>()
                   .As<IUserStore<ApplicationUser>>()
                   .WithParameter((pi, ctx) => { return pi.Name == "context"; },
                                  (pi, ctx) => { return ctx.Resolve<IDataContext>(); }
                              );
            builder.RegisterType<UserManager<ApplicationUser>>().As<UserManager<ApplicationUser>>();    
