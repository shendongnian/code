    UrlHelper Url { get; set; }
    [TestFixtureSetUp]
    public void FixtureSetUp()
    {
        var routes = new RouteCollection();
        RouteConfig.RegisterRoutes(routes);
        
        var httpContext = Substitute.For<HttpContextBase>();
        httpContext.Response.ApplyAppPathModifier(Arg.Any<string>())
            .Returns(ctx => ctx.Arg<string>());
        var requestContext = new RequestContext(httpContext, new RouteData());
        Url = new UrlHelper(requestContext, routes);
    }
    // Pages
    [Test]
    public void HomePage()
    {
        Url.Action("home", "pages").ShouldEqual("/");
    }
    [Test]
    public void PageDetails()
    {
        Url.Action("details", "pages", new { slug = "contact" }).ShouldEqual("/pages/contact");
    }
