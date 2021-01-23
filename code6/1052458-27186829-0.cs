	public static void RegisterAuth(IAppBuilder app)
	{
        // other code
		app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        // other code
    }
