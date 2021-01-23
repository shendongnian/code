		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			var kernel = context.Get<StandardKernel>();
			var userStore = kernel.Get<IUserStore<User, int>>();
			var manager = new ApplicationUserManager(userStore);
            //...
        }
