    internal sealed class Configuration : DbMigrationsConfiguration<Ubrasoft.Freeman.WebApi.Db.MainDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CodeGenerator = new CustomMigrationCodeGenerator();  
            SetSqlGenerator("System.Data.SqlClient", new CustomMigrationSqlGenerator());        
        }
        protected override void Seed(Ubrasoft.Freeman.WebApi.Db.MainDb context)
        {
        }
    }
