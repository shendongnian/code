        var configuration = GetConfiguration();
        var scaffolder = new MigrationScaffolder(configuration);
        scaffolder.Namespace = configuration.MigrationsNamespace;
        var scaffoldedMigration = scaffolder.Scaffold(name);
        System.IO.File.WriteAllText(scaffoldedMigration.MigrationId + ".cs", scaffoldedMigration.UserCode);
        System.IO.File.WriteAllText(scaffoldedMigration.MigrationId + ".Designer.cs", scaffoldedMigration.DesignerCode);
        System.IO.File.WriteAllText(scaffoldedMigration.MigrationId + ".resx", BuildResx(scaffoldedMigration.Resources));
