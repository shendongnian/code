    class Program
    {
        static void Main(string[] args)
        {
            using (var ss = new DataScope(@"connString"))
            {
                var db = DataScope.DatabaseConnection;
                var pk = 2;
                var sql = db.Beats.AsQueryable();
                sql = sql.Where(PKGreaterThan(pk));
                var res = sql.ToList();
            }
        }
        static string PKName { get { return "BeatID"; } }
        static PropertyInfo PKProperty()
        {
            var output = typeof(Beat).GetProperties().Where(p => p.Name == PKName).SingleOrDefault();
            return output;
        }
        static Expression<Func<Beat, bool>> PKGreaterThan(int pk)
        {
            var beatParameter = Expression.Parameter(typeof(Beat));
            var beatPKProperty = Expression.Property(beatParameter, PKProperty());
            var beatPKGreaterThanPK = Expression.GreaterThan(beatPKProperty, Expression.Constant(pk));
            var output = Expression.Lambda<Func<Beat, bool>>(beatPKGreaterThanPK, beatParameter);
            return output;
        }
    }
