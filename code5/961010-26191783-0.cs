    var configuration = new DbMigrationsConfiguration
    {
        AutomaticMigrationsEnabled = true,
        ContextType = typeof(MyContext),
        MigrationsAssembly = typeof(MyContext).Assembly
    };
    
    var migrator = new DbMigrator(configuration);
    
    var scriptor = new MigratorScriptingDecorator(migrator);
    string script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null);
    
    Console.WriteLine(script);
