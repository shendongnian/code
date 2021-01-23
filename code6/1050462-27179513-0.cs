    /// <summary>
	/// 	Class used to generate the code migrations and SQL script based on the Models and update the database.
    ///     (I.e., runs PowerShell's Add-Migration and Update-Database, and creates a PostgreSQL script.)
	///     See: http://stackoverflow.com/questions/20374783/enable-entity-framework-migrations-in-mono#20382226
	/// 
    ///     Usage: run by setting Zk.Migrations as Startup project and pressing play.
    /// 
	/// 	Classes of namespace EntityFramework.PostgreSql obtained from:
	///     https://github.com/darionato/PostgreSqlMigrationSqlGenerator. License is included.
	/// </summary>
	class MigrationsTool
	{
        /// <summary>
        ///     The entry point of the program, where the program control starts and ends.
        /// </summary>
		public static void Main()
		{
            // USER INPUT /////////////////////////////////////////////////////////////////////////////////
            // Always first create a new database migration with DatabaseStep.ADD_MIGRATION,
            // and include the created files in the project and set resource file to EmbeddedResource. 
            // After creating a migration run UPDATE_DATABASE to update the database.
            const DatabaseStep step = DatabaseStep.UPDATE_DATABASE;
            // Specify the name of the database migration in case of ADD-MIGRATION.
            // Note: Make sure to create a new name for each new migration.
            //       After creating migration include the files in the folder by right clicking on 
            //       Zk.Migrations and selecting "Add files from folder". Then add the .cs, .resx and
            //       .Designer.cs files with the name specified below.
            //       Last but not least set the .resx file's build action to EmbeddedResource by right
            //       clicking on it.
            // Make sure that the Setup.postgresql script has run manually to create the database user.
            const string MIGRATION_NAME = "CalendarAndUser";
            // END USER INPUT /////////////////////////////////////////////////////////////////////////////
            // Get executing path from which the location of the Update_Scripts and new Migrations can be determined.
            var executingPath = AppDomain.CurrentDomain.BaseDirectory; 
            // Add a new migration (PowerShell: Add-Migration)
            if (step == DatabaseStep.ADD_MIGRATION) {
    
                // Initialize the wrapper classes around the Entity Framework PowerShell API.
                var config = new Configuration();
                var scaffolder = new MigrationScaffolder(config); 
                var migration = scaffolder.Scaffold(MIGRATION_NAME);
        
                // Place migration code in main project "Migrations" folder and migration scripts in "App_Data"
                var migrationsPath = Regex.Replace(executingPath, "bin/.*", "");
            
                // Write migrations
                File.WriteAllText (migrationsPath + MIGRATION_NAME + ".cs", migration.UserCode);
                File.WriteAllText (migrationsPath + MIGRATION_NAME + ".Designer.cs", migration.DesignerCode);
                using (var writer = new ResXResourceWriter (migrationsPath + MIGRATION_NAME + ".resx")) 
                {
                    foreach (var resource in migration.Resources) 
                    {
                        writer.AddResource(resource.Key, resource.Value);
                    }
                }
                Console.WriteLine("EF code migration {0} written to Migrations folder...\n\n" +
                    "Next step is to include the .cs, .resx and .Designer.cs file in the project" + 
                    "by right clicking on the project and selecting " +  
                    "\"Add files from folder.\"\n" +
                    "Then right click on {0}.resx and set build action to \"EmbeddedResource\""
                    , migration.MigrationId);
            }
            else if (step == DatabaseStep.CREATE_SCRIPT)
            {
                var config = new Configuration();
                var migrator = new DbMigrator(config);
                var scriptor = new MigratorScriptingDecorator(migrator);
                // Determine name of the previous run migration if exists.
                string lastMigration = migrator.GetDatabaseMigrations().LastOrDefault();
                // Get the script 
                string script = scriptor.ScriptUpdate(sourceMigration: lastMigration, targetMigration: MIGRATION_NAME);
                // Create the PostgreSQL update script based on last migration on database and 
                // current migration.
                string formattedScript = string.Format
                    ("/* * * * * * * * * * * * * * * * * * * * * * *\n" +
                    " *\n" +
                    " * Migration:\t\t{0}\n *\n" +
                    " * Date and time:\t{1}\n" +
                    " *\n" +
                    " * * * * * * * * * * * * * * * * * * * * * * */\n\n" +
                    "{2}", 
                    MIGRATION_NAME, 
                    DateTime.Now,
                    script);
                // Write string to file in Migrations folder of main project
                var updateScriptPath = Regex.Replace(executingPath, "Zk.Migrations/.*", "Zk/App_Data/Migrations/");
                File.WriteAllText(updateScriptPath + MIGRATION_NAME + ".postgresql", formattedScript);
                Console.WriteLine("Update script {0}.postgresql written to Zk/App_Data/Migrations folder.\n" +
                    "Please include the script by right clicking on the folder and selecting " + 
                    "\"Add files to folder\"," +
                    "\nIt is recommended to prefix the filename with the current datetime.", 
                    MIGRATION_NAME);
            }
            // If a new migration is created the database can be updated. (PowerShell: Update-Database)
            else if (step == DatabaseStep.UPDATE_DATABASE)
            {
                var config = new Configuration();
                var migrator = new DbMigrator(config);
                // Write to database
                migrator.Update();
                // Show which migrations were applied.
                var migrationNames = string.Join(", ", migrator.GetDatabaseMigrations().ToArray().First());
                Console.WriteLine("Applied migration {0} to database.", migrationNames);
            }
		}
        /// <summary>
        ///     Enumeration for specifying the step in the migration.
        /// </summary>
        private enum DatabaseStep 
        {
            ADD_MIGRATION,
            CREATE_SCRIPT,
            UPDATE_DATABASE
        }
	}
