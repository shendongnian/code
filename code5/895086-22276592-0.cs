    public class Bll
    {
        IDatabase _db;
        public Bll(IDatabase db)
        {
            _db = db;
        }
        public void SomeMethod()
        {
            // Use db here
        }
    }
