    private IList<Store> GetStores(int id)
    {
        var stlist = db.Stores.Where(m => m.CustomerId == id && m.Isactive).ToList();
        return (stlist);
    }
