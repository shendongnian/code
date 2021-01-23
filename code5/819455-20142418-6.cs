    public IEnumerable GetCollection(MvcDemoDBEntities db, Type Class)
    {
        //get the type of db
        var dbType = db.GetType();
        //get the name of the type Class
        var name = Class.Name;
        //get the property
        var prop = dbType.GetProperty(name);
        //read the property and return
        return prop.GetValue(db);
    }
