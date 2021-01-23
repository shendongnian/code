    [TestFixture]
    public class InventoryTests
    {
        [SetUp]
        public void Init()
        {
            // warm up EF.
            using (var context = new ReportingDbContext())
            {
                context.Database.Initialize(false);
            }
            // init other stuff
        }
      // tests go here
    }
