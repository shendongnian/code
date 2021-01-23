        if (env.IsDevelopment())
        {
            // Uncomment when done testing error handling
            //app.UseBrowserLink();
            //app.UseDeveloperExceptionPage();
            //app.UseDatabaseErrorPage();
            // Comment when done testing error handling
            app.UseExceptionHandler("/Home/Error");
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            //For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                        .Database.Migrate();
                }
            }
            catch { }
        }
        
        // Lines Skipped For Brevity ....
        // Add this line above app.Mvc in Startup.cs to Handle 404s etc
        app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
