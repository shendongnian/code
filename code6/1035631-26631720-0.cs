    public class ItemRepository
    {
        private Database _db;
        public ItemRepository(Func<Database> dbFactory)
        {
            _db = dbFactory();
        }
        
        ...
    }
