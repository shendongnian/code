    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    namespace Ef6Test {
    public class Program {
        public static void Main(string[] args) {
            ExecDb1();
            ExecDB2();
           ExecDbCtx3();
        }
        private static void ExecDb1() {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Ef6Ctx, Ef6MigConf>());
            WhichDb.DbName = "HACKDB1";
            WhichDb.ConnType = ConnType.CtxViaDbConn;
            var sqlConn = GetSqlConn4DBName(WhichDb.DbName);
            var context = new Ef6Ctx(sqlConn);
            context.Database.Initialize(true);
            Console.WriteLine(WhichDb.DbName, context.Database.Exists() );
            AddJunk(context);
            //sqlConn.Close();  //?? whatever other considerations, dispose of context etc...
        }
        private static void ExecDB2() {
            // yes other its default again reset this !!!!
            WhichDb.DbName = "HACKDB2";
            WhichDb.ConnType = ConnType.CtxViaDbConn;
            var sqlConn2 = GetSqlConn4DBName(WhichDb.DbName);
            var context2 = new Ef6Ctx2(sqlConn2);
            Console.WriteLine(context2.Database.Exists());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Ef6Ctx2, Ef6MigConf2>());
            context2.Database.Initialize(true);
            Console.WriteLine(WhichDb.DbName, context2.Database.Exists());
            AddJunk(context2);
        }
        private static void ExecDbCtx3() {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Ef6Ctx3, Ef6MigConf3>());
            // Database.SetInitializer(new CreateDatabaseIfNotExists<Ef6Ctx3>());
            // Database.SetInitializer(null);
            WhichDb.ConnectionName = "AppCfgName";
            WhichDb.ConnType = ConnType.CtxViaConnectionName;
            var context3 = new Ef6Ctx3(WhichDb.ConnectionName);
            context3.Database.Initialize(true);
            Console.WriteLine(WhichDb.ConnectionName, context3.Database.Exists());
            AddJunk(context3);
        }
        public static class WhichDb {
            public static string DbName { get; set; }
            public static string ConnectionName { get; set; }
            public static ConnType ConnType { get; set; }
        }
        public enum ConnType {
            CtxViaDbConn,
            CtxViaConnectionName
        }
        private static void AddJunk(DbContext context) {
            var poco = new pocotest();
            poco.f1 = DateTime.Now.ToString();
            //  poco.f2 = "Did somebody step on a duck?";  //comment in for second run
            context.Set<pocotest>().Add(poco);
            context.SaveChanges();
        }
        public static DbConnection GetSqlConn4DBName(string dbName) {
            var sqlConnFact = new SqlConnectionFactory(
                "Data Source=localhost; Integrated Security=True; MultipleActiveResultSets=True");
            var sqlConn = sqlConnFact.CreateConnection(dbName);
            return sqlConn;
        }
    }
    public class MigrationsContextFactory : IDbContextFactory<Ef6Ctx> {
        public Ef6Ctx Create() {
            switch (Program.WhichDb.ConnType) {
                case Program.ConnType.CtxViaDbConn:
                    var sqlConn = Program.GetSqlConn4DBName(Program.WhichDb.DbName); // NASTY but it works
                    return new Ef6Ctx(sqlConn);
                case Program.ConnType.CtxViaConnectionName:
                    return new Ef6Ctx(Program.WhichDb.ConnectionName);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class MigrationsContextFactory2 : IDbContextFactory<Ef6Ctx2> {
        public Ef6Ctx2 Create() {
            switch (Program.WhichDb.ConnType) {
                case Program.ConnType.CtxViaDbConn:
                    var sqlConn = Program.GetSqlConn4DBName(Program.WhichDb.DbName); // NASTY but it works
                    return new Ef6Ctx2(sqlConn);
                case Program.ConnType.CtxViaConnectionName:
                    return new Ef6Ctx2(Program.WhichDb.ConnectionName);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class MigrationsContextFactory3 : IDbContextFactory<Ef6Ctx3> {
        public Ef6Ctx3 Create() {
            switch (Program.WhichDb.ConnType) {
                case Program.ConnType.CtxViaDbConn:
                    var sqlConn = Program.GetSqlConn4DBName(Program.WhichDb.DbName); // NASTY but it works
                    return new Ef6Ctx3(sqlConn);
                case Program.ConnType.CtxViaConnectionName:
                    return new Ef6Ctx3(Program.WhichDb.ConnectionName);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
     }
    public class Ef6MigConf : DbMigrationsConfiguration<Ef6Ctx> {
        public Ef6MigConf() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
     }
    public class Ef6MigConf2 : DbMigrationsConfiguration<Ef6Ctx2> {
        public Ef6MigConf2() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
     }
     public class Ef6MigConf3 : DbMigrationsConfiguration<Ef6Ctx3> {
        public Ef6MigConf3() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
    public class pocotest {
        public int Id { get; set; }
        public string f1 { get; set; }
     public string f2 { get; set; } // comment in for second run
     public string f2a { get; set; } // comment in for second run
      public string f3 { get; set; } // comment in for second run
     public string f5 { get; set; } // comment in for second run
     public string f6b { get; set; } // comment in for second run
    }
    public class Ef6Ctx : DbContext {
        public Ef6Ctx(DbConnection dbConn) : base(dbConn, true) { }
        public Ef6Ctx(string connectionName) : base(connectionName) { }
        public DbSet<pocotest> poco1s { get; set; }
    }
    public class Ef6Ctx2 : DbContext {
        public Ef6Ctx2(DbConnection dbConn) : base(dbConn, true) { }
        public Ef6Ctx2(string connectionName) : base(connectionName) { }
        public DbSet<pocotest> poco1s { get; set; }
    }
    }
