    HttpContext.Current = new HttpContext(
        new HttpRequest("", "http://tempuri.org", "ip=127.0.0.1"),
        new HttpResponse(new StringWriter()))
        {
            User = new GenericPrincipal(
                new GenericIdentity("username"),
                new string[0]),
        };
