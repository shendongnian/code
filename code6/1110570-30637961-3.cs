    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddCors();
    }
    
    public void Configure(IApplicationBuilder app)
    {
        app.UseCors(builder =>
    	{
    	    builder.WithOrigins("http://some.origin.com")
    	           .WithMethods("GET", "POST")
    	           .AllowAnyHeader();
    	});
    }
