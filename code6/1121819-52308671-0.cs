    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();   // <-- Add this !!!!!
        }
    
        app.UseHttpsRedirection(); // <-- Add this !!!!!
        app.UseStaticFiles();
        app.UseCookiePolicy();
    
        app.UseMvc();
    }
