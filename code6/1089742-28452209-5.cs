    internal class DbQuickInsert<T> : DbContext where T : class
    {
        public DbSet<T> MyRecords { get; set; }
        public DbQuickInsert(string databasename) : base(databasename)
        {
        }
    }
    internal static class HelperQuick
    {
        public static void InsertIntoDatabase<T>(this IEnumerable<T> records, string databasename) where T : class
        {
            var qi = new DbQuickInsert<T>(databasename);
            qi.Configuration.AutoDetectChangesEnabled = false;
            qi.BulkInsert(records);
            qi.SaveChanges();
        }
    }
