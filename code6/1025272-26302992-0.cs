        [TestFixtureSetUp]
        public static void SetupFixture() //create database
        {
            using (var context = new XEntities())
            {
                context.Setup();
            }
        }
        [TestFixtureTearDown]
        public void TearDown() //drop database
        {
            using (var context = new XEntities())
            {
                context.Database.Delete();
            }
        }
        [SetUp]
        public void Setup() //Clear entities before each test so they are independent
        {
            using (var context = new XEntities())
            {
                foreach (var tableRow in context.Table)
                {
                    context.Table.Remove(tableRow);
                }
                context.SaveChanges();
            }
        }
