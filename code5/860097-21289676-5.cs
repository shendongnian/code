    private static void Main(string[] args)
    {
        using (var context = new TestContext())
        {
            context.SaveChanges();
            context.Tests.Add(new Test(new DateTime(2013, 6, 1)));
            context.Tests.Add(new Test(new DateTime(2014, 6, 1)));
            context.SaveChanges();
            DateTime start = new DateTime(2013, 1, 1);
            DateTime end = new DateTime(2014, 1, 1);
            var query = context.Tests.IsBetween(row => row.Example, start, end);
            var traceString = query.ToString();
            var result = query.ToList();
            Debugger.Break();
        }
    }
    public class Test
    {
        public Test()
        {
            Example = DateTime.Now;
        }
        public Test(DateTime time)
        {
            Example = time;
        }
        public int TestId { get; set; }
        public DateTime Example { get; set; }
    }
    public class TestContext : DbContext
    {
        public DbSet<Test> Tests { get; set; } 
    }
