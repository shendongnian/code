        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
               builder.WithOrigins(new[] { "http://localhost:4200" }).AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
               );
            app.UseOwin(a => a.UseNancy(b => b.Bootstrapper = new NancyBootstrap(this.Container)));
        }
