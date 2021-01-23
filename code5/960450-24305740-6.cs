    public void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<IAppPrincipal>(
                    new PerRequestLifetimeManager(),
                    new InjectionFactory(c => CreateAppPrincipal()));
    }
    public IAppPrincipal CreateAppPrincipal()
    {
        var principal = new AppPrincipal();
        principal.UserId = //Retrieve userId from your IPrincipal (HttpContext.Current.User)
        principal.Role = //Retrieve role from your IPrincipal (HttpContext.Current.User)
        return principal;
    }
