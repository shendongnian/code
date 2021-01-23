    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton()
        {
        }
        private Singleton()
        {
            try
            {
                Database = new SqliteDatabase<int>(myConn);
                Database.Init();
            }
            catch (Exception ex)
            {
                // Handle errors
            }
        }
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
