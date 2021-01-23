    public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/hello");
            app.UseErrorPage();
            NancyOptions nancyOptions = new NancyOptions();
            app.UseNancy(options => 
                options.PassThroughWhenStatusCodesAre(HttpStatusCode.InternalServerError)); 
        }
