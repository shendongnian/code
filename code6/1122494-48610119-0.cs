    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        // Add header:
        app.Use((context, next) =>
        {
            context.Response.Headers["Access-Control-Allow-Origin"] = "*";
            return next.Invoke();
        });
        app.UseMvc();
    }
