    using StaticDotNet.EntityFrameworkCore.ModelConfiguration;
    public void ConfigureServices(IServiceCollection services)
    {
        Assembly[] assemblies = new Assembly[]
        {
            // Add your assembiles here.
        };
        services.AddDbContext<ExampleDbContext>( x => x
            .AddEntityTypeConfigurations( assemblies )
        );
    }
