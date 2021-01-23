    Uri uri = new Uri("http://localhost?key1=value1&key2=value2&key3=value3&&key4=value4");
    HttpRequest httpRequest = new HttpRequest(string.Empty, uri.ToString(),
                                                uri.Query.TrimStart('?'));
    HttpContext httpContext = new HttpContext(httpRequest, new HttpResponse(new StringWriter()));
    HttpSessionStateContainer sessionContainer = new HttpSessionStateContainer("id",
                                            new SessionStateItemCollection(),
                                            new HttpStaticObjectsCollection(),
                                            10, true, HttpCookieMode.AutoDetect,
                                            SessionStateMode.InProc, false);
    SessionStateUtility.AddHttpSessionStateToContext(
                                                 httpContext, sessionContainer);
    HttpContext.Current = httpContext; 
