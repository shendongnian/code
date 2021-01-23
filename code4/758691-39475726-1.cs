      public class MyApplication : ApplicationEventHandler
      {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
          HandleStatisticsMigration();
        }
    
        private static void HandleStatisticsMigration()
        {
          const string productName = "YourTableName";
          var currentVersion = new SemVersion(0, 0, 0);
    
          // get all migrations for "YourTableName" already executed
          var migrations = ApplicationContext.Current.Services.MigrationEntryService.GetAll(productName);
    
         // get the latest migration for "YourTableName" executed
         var latestMigration = migrations.OrderByDescending(x => x.Version).FirstOrDefault();
    
         if (latestMigration != null)
           currentVersion = latestMigration.Version;
    
         var targetVersion = new SemVersion(1, 0, 1);
         if (targetVersion == currentVersion)
           return;
    
         var migrationsRunner = new MigrationRunner(
           ApplicationContext.Current.Services.MigrationEntryService,
           ApplicationContext.Current.ProfilingLogger.Logger,
           currentVersion,
           targetVersion,
           productName);
    
         try
         {
           migrationsRunner.Execute(UmbracoContext.Current.Application.DatabaseContext.Database);
         }
         catch (Exception e)
         {
           LogHelper.Error<MyApplication>("Error running YourTableName migration", e);
         }
       }
     }
