    string sharedCookie;
    var securityWebService = new SecurityWebServiceClient(CreateCustomBinding(), new EndpointAddress("http://localhost/SecurityWebService.svc"));
    using (new OperationContextScope(securityWebService.InnerChannel))
    {
        securityWebService.Login("UserName", "Password");
        var response = (HttpResponseMessageProperty)OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name];
        var cookieHeader = response.Headers["Set-Cookie"];
        var container = new CookieContainer();
        container.SetCookies(new Uri("http://localhost"), cookiesString);
        var cookies = container.GetCookies(new Uri("http://localhost"));
        var authCookie = cookies["nameOfAuthCookie"];
        if (authCookie != null)
             sharedCookie = authCookie.ToString();
    }
