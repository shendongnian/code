    Bind<IIdentity>()
        .To<WebIdentity>()
         ...
    Bind<IIdentity>()
        .ToMethod(x => HttpContext.Current.User.Identity)
        .WhenInjectedInto(typeof(WebIdentity))
        ...
    Bind<IPrincipal>()
        .To<WebsitePrincipal>()
        ...
