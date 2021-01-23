    public void ConfigureServices(IServiceCollection services)
    {
         // other code
        services.AddSwaggerGen(c =>
        {
            // other configurations
            c.DocumentFilter<ShowInSwaggerFilter>();
        });
    }
