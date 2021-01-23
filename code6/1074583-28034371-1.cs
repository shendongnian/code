    container.RegisterPerWebRequest<IAuthenticationManager>(
    () =>
    {
        IOwinContext context = null;
        try
        {
            context = HttpContext.Current.GetOwinContext();
        }
        catch (InvalidOperationException)
        {
           // Please note that the `IsVerifying()` method is 
           // declared in SimpleInjector.Advanced. 
           if (container.IsVerifying())
            {
                return new FakeAuthenticationManager();
            }
            throw;
        }
        return context.Authentication;
    });
