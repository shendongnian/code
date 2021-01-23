    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy =
            new Lazy<Singleton>(() => new Singleton());
    
        public static Singleton Instance { get { return lazy.Value; } }
        private Singleton()
        {
            try 
            {
                Database = new SqliteDatabase<int>(myConn);
                Database.Init();
            }
            catch(Exception ex)
            {
               // Handle errors
            }
        }
