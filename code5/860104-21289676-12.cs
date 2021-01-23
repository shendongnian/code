        private static void Main(string[] args)
        {
            using (var context = new TestContext())
            {
                DateTime start = new DateTime(2013, 1, 1);
                DateTime end = new DateTime(2014, 1, 1);
                var query = context.Tests.IsBetween(row => row.Example, start, end);
                var traceString = query.ToString(); // Generates the where clause: WHERE ([Extent1].[Example] >= @p__linq__0) AND ([Extent1].[Example] < @p__linq__1)
                var query2 = context.Tests.ComplexTest(row => row.Param1, row => row.Param2);
                var traceString2 = query2.ToString(); //Generates the where clause: WHERE (N'Foo' = [Extent1].[Param1]) AND ([Extent1].[Param1] IS NOT NULL) AND (2 = [Extent1].[Param2])
                Debugger.Break();
            }
        }
        public class Test
        {
            public int TestId { get; set; }
            public DateTime Example { get; set; }
            public string Param1 { get; set; }
            public int Param2 { get; set; }
        }
        public class TestContext : DbContext
        {
            public DbSet<Test> Tests { get; set; } 
        }
        public static IQueryable<T> IsBetween<T>(this IQueryable<T> query, Expression<Func<T, DateTime>> dateSelector, DateTime start, DateTime end)
        {
            Expression<Func<DateTime, bool>> testQuery = date => date >= start && date < end;
            var newQuery = LambadaConverter.Convert<T, bool>(testQuery, dateSelector);
            return query.Where(newQuery);
        }
        public static IQueryable<T> ComplexTest<T>(this IQueryable<T> query, Expression<Func<T, string>> selector1, Expression<Func<T, int>> selector2)
        {
            Expression<Func<string, int, bool>> testQuery = (str, num) => str == "Foo" && num == 2;
            var newQuery = LambadaConverter.Convert<T, bool>(testQuery, selector1, selector2);
            return query.Where(newQuery);
        }
