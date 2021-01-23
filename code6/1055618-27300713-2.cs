    // upside: simple SomeDataContext.Instance for external users
    // downside: more code in SomeDataContext
    partial class SomeDataContext : DataContextBase
    {
        private const string DatabaseFile = "blablabla.mdf";
        public static SomeDataContext Instance
        {
            get
            {
                return new SomeDataContext(GetConnectionString(DatabaseFile));
            }
        }
    }
    abstract class DataContextBase
    {
        protected static string GetConnectionString(string databaseFile)
        {
            return string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True", databaseFile);
        }
    }
    // e.g. using (var context = SomeDataContext.Instance)
