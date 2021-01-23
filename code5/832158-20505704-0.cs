    [TestClass]
    public void SomeTestClass
    {
        [TestMethod]
        public void ShouldLoadOnlyRequiredCollections()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<HomesContext>());
            var db = new HomesContext();
            Assert.IsFalse(db.Homes.Any());
            var home = db.Homes.Create();
            db.Homes.Add(home);
            home.Staff.Add(new Staff { Name = "wilma" });
            home.Staff.Add(new Staff { Name = "betty" });
            home.Residents.Add(new Resident { Name = "fred" });
            home.Residents.Add(new Resident { Name = "barney" });
            db.SaveChanges();
            db = null;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HomesContext>());
            var sb = new StringBuilder();
            db = new HomesContext();
            db.Database.Log = ((s) => { sb.Append(s + "\r"); });
            Assert.IsTrue(db.Homes.Any());
            string log;
            log = sb.ToString();
            Assert.IsTrue(sb.ToString().Contains("FROM [dbo].[Homes]"));
            sb = new StringBuilder(); //ok get residents
            var q = db.Homes.Include("Residents");
            Assert.IsTrue(string.IsNullOrEmpty(sb.ToString()));
            var lst = q.ToList();
            log = sb.ToString();
            Assert.IsTrue(sb.ToString().Contains("[dbo].[Homes]"));
            Assert.IsTrue(sb.ToString().Contains("[dbo].[Residents]"));
            Assert.IsTrue(!sb.ToString().Contains("[dbo].[Staff]"));
            sb = new StringBuilder(); //get staff
            q = db.Homes.Include("Staff");
            Assert.IsTrue(string.IsNullOrEmpty(sb.ToString()));
            lst = q.ToList();
            log = sb.ToString();
            Assert.IsTrue(log.Contains("[dbo].[Homes]"));
            Assert.IsTrue(!log.Contains("[dbo].[Residents]"));
            Assert.IsTrue(log.Contains("[dbo].[Staffs"));
            sb = new StringBuilder(); //get residents and staff
            q = db.Homes.Include("Staff");
            q = q.Include("Residents");
            lst = q.ToList();
            log = sb.ToString();
            Assert.IsTrue(log.Contains("[dbo].[Homes]"));
            Assert.IsTrue(log.Contains("[dbo].[Residents]"));
            Assert.IsTrue(log.Contains("[dbo].[Staffs]"));
        }
    }
    public class HomesContext:DbContext
    {
        public DbSet<Home> Homes { get; set; }
    }
    public class Home
    {
        public Home()
        {
            Staff = new List<Staff>();
            Residents = new List<Resident>();
        }
        public int HomeId { get; set; }
        public string HomeName { get; set; }
        public int MaxResidents { get; set; }
        public int MaxStaff { get; set; }
        public int CurrentResidents { get; set; }
        [NotMapped]
        public int CurrentStaff { get; set; }
        public IList<Staff> Staff { get; set; }
        public IList<Resident> Residents { get; set; }
    }
    public class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public int HomeId { get; set; }
        public Home Home { get; set; }
    }
    public class Resident
    {
        public int ResidentId { get; set; }
        public string Name { get; set; }
        public int HomeId { get; set; }
        public Home Home { get; set; }
    }
