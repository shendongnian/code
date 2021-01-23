    routes.MapHttpRoute(
        "MyRoute",
        "api/{controller}/{id}/{p1}/{p2}",
        new { id = UrlParameter.Optional, p1 = UrlParameter.Optional, p2 = UrlParameter.Optional, Action = "Get"});
    /api/controller/2134324/123213/31232312
    public HttpResponseMessage Get(int id, int p1, int p2) {};
