    public override void MigrateDb() {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MYDbContext, MYSECIALMigrationConfiguration>());
           // Context = GetDefaultContext();  // check if a new context is really needed here 
            Context.Database.Initialize(true);
        }
    public class MYSPECIALMigrationConfiguration : MYBaseMigrationConfiguration<MYDbContext>{  }
     public abstract class MYBaseMigrationConfiguration<TContext> : DbMigrationsConfiguration<TContext> 
        where TContext  : DbContext{
     
        protected  MYBaseMigrationConfiguration() {
            AutomaticMigrationsEnabled = true;  // you can still chnage this later if you do so before triggering Update
            AutomaticMigrationDataLossAllowed = true; // you can still chnage this later if you do so before triggering Update
           
        }
