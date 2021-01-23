    public void Configure(IApplicationBuilder app)
    {
        if (_env.IsProduction())
        {
            app.UseMiddleware<AlwaysHttpsMiddleware>();
        }
     }
