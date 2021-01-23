    public class ItemRepository
    {
        private Func<Database> _dbFactory;
        public ItemRepository(Func<Database> dbFactory)
        {
            _dbFactory = dbFactory;
        }
        
        public void Update() {
            var db = _dbFactory();
            // Now use db wherever you were using _db()
            ...
        }
    }
