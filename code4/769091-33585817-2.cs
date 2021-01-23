    public class CheckAndMigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration>
        : IDatabaseInitializer<TContext>
        where TContext : DbContext
        where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        public virtual void InitializeDatabase(TContext context)
        {
            var migratorBase = ((MigratorBase)new DbMigrator(Activator.CreateInstance<TMigrationsConfiguration>()));
            var pendingMigrations = migratorBase.GetPendingMigrations().ToArray();
            if (pendingMigrations.Any()) // Is there anything to migrate?
            {
                // Applying all migrations
                migratorBase.Update();
                // Here all migrations are applied
                foreach (var pendingMigration in pendingMigrations)
                {
                    var migrationName = pendingMigration.Substring(pendingMigration.IndexOf('_') + 1);
                    var t = typeof(TMigrationsConfiguration).Assembly.GetType(
                        typeof(TMigrationsConfiguration).Namespace + "." + migrationName);
                    if (t != null 
                       && t.GetInterfaces().Any(x => x.IsGenericType 
                          && x.GetGenericTypeDefinition() == typeof(IMigrationSeed<>)))
                    {
                        // Apply migration seed
                        var seedMigration = (IMigrationSeed<TContext>)Activator.CreateInstance(t);
                        seedMigration.Seed(context);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
