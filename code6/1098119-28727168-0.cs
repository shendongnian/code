    kernel.Bind<IAuthenticationManager>().ToMethod(c =>	HttpContext.Current.GetOwinContext().Authentication); //.InRequestScope();
	kernel.Bind<IRoleStore<ApplicationRole, int>>().To<RoleStore<ApplicationRole, int, ApplicationUserRole>>()
				.WithConstructorArgument("context", context => kernel.Get<ApplicationDbContext>());
	kernel.Bind<IUserStore<ApplicationUser, int>>()
				.To<UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>>()
				.WithConstructorArgument("context", context => kernel.Get<ApplicationDbContext>());
