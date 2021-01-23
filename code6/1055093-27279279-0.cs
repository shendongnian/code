    public static Dog Get(string dogname) 
    {
        using (var db = new MyDataContext())
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            return db.Dogs.Single(d => d.name == dogname);
        }
    }
