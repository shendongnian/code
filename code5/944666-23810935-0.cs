     container.RegisterType(typeof(UserManager<>),
                new InjectionConstructor(typeof(IUserStore<>)));
                container.RegisterType<Microsoft.AspNet.Identity.IUser>(new InjectionFactory(c => c.Resolve<Microsoft.AspNet.Identity.IUser>()));
                container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
                container.RegisterType<IdentityUser, ApplicationUser>(new ContainerControlledLifetimeManager());
                container.RegisterType<DbContext, ApplicationDbContext>(new ContainerControlledLifetimeManager());
