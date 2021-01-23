    kernel.Bind<IDBContext>().To<DBContext>().InRequestScope(); //It's good practice to use interface
    kernel.Bind<DBContext>().ToSelf().InRequestScope(); //You can also do it this way
    kernel.Bind<IUserStore<User>>().To<UserStore<User>>()
                .InRequestScope()
                .WithConstructorArgument("context", kernel.Get<IDBContext>());
    kernel.Bind<UserManager<User>>().ToSelf()
                .InRequestScope();
