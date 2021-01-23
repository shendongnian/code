    public IServiceProvider ConfigureServices( IServiceCollection services )
    {
        MyContext.isMigration = false;
        var configuration = new Configuration().AddJsonFile( "config.json" );
        services.AddEntityFramework( configuration )
            .AddSqlServer()
            .AddDbContext<MyDbContext>( config => config.UseSqlServer() );
        // ...
    }
