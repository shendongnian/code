    public class Testable : ITestable
    {
        private readonly Func<IDb> dbFactory;  
        public class Testable(Func<IDb> dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public int TestMethod()
        {
            var db = dbFactory();
            return db.GetNumbers() + 20;
        }
    }
