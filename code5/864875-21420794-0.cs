    public void Configuration(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        config.Routes.MapHttpRoute("default", "api/{controller}/{id}");
    
        //config.MessageHandlers.Add(new PresharedKeyAuthorizer());
    
        app.Use((IOwinContext context, Func<Task> next) =>
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "superstar"));
    
            var identity = new ClaimsIdentity(claims, "PresharedKey");
            var principal = new ClaimsPrincipal(identity);
    
            context.Request.User = principal;
            return next.Invoke();
        });
    
        app.UseWebApi(config);
    }
