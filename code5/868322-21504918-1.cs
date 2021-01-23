    class Context : DbContext
    {
        public DbSet<Foo> Foo { get; set; }
    }
    public class Foo
    {
        public int FooId { get; set; }
        public DateTime Date { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var query = context.Foo;
                var dates = query.Select(x => EntityFunctions.DiffDays(query.Min(y => y.Date), x.Date));
                var result = dates.ToString();
                Debugger.Break();
            }
       } 
    }
