    kernel.Bind<IDbContext, DbContext>()
    	.To<BlogContext>()
    	.InRequestScope();
    
    kernel.Bind<IUserStore<User>>()
    	.To<UserStore<User>>()
    	.InRequestScope();
    
    kernel.Bind<IDataProtectionProvider>()
    	.To<DpapiDataProtectionProvider>()
    	.InRequestScope()
    	.WithConstructorArgument("ApplicationName");
    
    kernel.Bind<ApplicationUserManager>().ToSelf().InRequestScope()
    	.WithPropertyValue("UserTokenProvider",
    		new DataProtectorTokenProvider<User>(
    			kernel.Get<IDataProtectionProvider>().Create("EmailConfirmation")
    			));
