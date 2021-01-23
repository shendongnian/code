    container.RegisterPerWebRequest<IAuthenticationManager>(() =>
    {
        try
        {
            return HttpContext.Current.GetOwinContext().Authentication;
        }
        catch (InvalidOperationException)
        {
            if (AdvancedExtensions.IsVerifying(container))
                return new OwinContext(new Dictionary<string, object>()).Authentication;
            throw;
        }
    });
