    public IEnumerable<Store> GetStores()
    {
        using (var db = new MyDbContext())
        {
            return db.Stores;
        }
    }
