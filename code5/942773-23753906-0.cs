    [TestClass]
    public class UnitTestClass
    {
        private static string testConnString;
       
        [TestInitialize]
        public void Initialize()
        {
            testConnString = GetTestConnString();
            using (MyContext db = new MyContext(testConnString, new DropCreateDatabaseAlways<MyContext>()))
            {
                db.UnderlyingContext.Connection.Open();
            }
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestCleanup]
        public void CleanUp()
        {
            using (MyContext db = new MyContext(testConnString))
            {
                db.Database.Delete();
            }
        }
        private static string GetTestConnString()
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = @"MYPC\SQLEXPRESS";
            csb.InitialCatalog = "DB"+Guid.NewGuid().ToString().Replace("-","");
            csb.IntegratedSecurity = true;
           return csb.ToString();
        }
    }
    public class MyContext : DbContext
    {
 
        private static IDatabaseInitializer<MyContext> _Initializer;
        public MyContext(string connString, IDatabaseInitializer<MyContext> initializer = null)
            : base(connString)
        {
            _Initializer = initializer;
        }
        public ObjectContext UnderlyingContext
        {
            get { return (this as IObjectContextAdapter).ObjectContext; }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (_Initializer != null)
            {
                Database.SetInitializer(_Initializer);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
