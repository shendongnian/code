            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            //app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.Use((context, next) => {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                return next.Invoke();
            });
            app.UseMvc();
            app.UseWebSockets();
            app.UseSignalR();
        }
