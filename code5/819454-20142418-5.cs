    public IEnumerable<TClass> GetCollection<TClass>(MvcDemoDBEntities db)
    {
        //get the type of db
        var dbType = db.GetType();
        //get the name of the type TClass
        var name = typeof(TClass).Name;
        //get the property
        var prop = dbType.GetProperty(name);
        //read the property and return
        return prop.GetValue(db);
    }
