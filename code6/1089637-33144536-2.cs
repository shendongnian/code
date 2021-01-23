    public void Configure(IApplicationBuilder app)
    {
        app.UseCookieAuthentication(options =>
        {
            options.AutomaticAuthentication = true;
        });
     
        // This must be before UseStaticFiles.
        app.UseProtectFolder(new ProtectFolderOptions
        {
            Path = "/Secret",
            PolicyName = "Authenticated"
        });
     
        app.UseStaticFiles();
     
        // ... more middleware
    }
