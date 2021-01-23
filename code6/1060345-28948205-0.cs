    container.RegisterPerWebRequest<IAuthenticationManager>(() => 
        AdvancedExtensions.IsVerifying(container) 
            ? new OwinContext(new Dictionary<string, object>()).Authentication 
            : HttpContext.Current.GetOwinContext().Authentication); 
 
