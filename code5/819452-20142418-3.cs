    public Dictionary<object, object> GetDetails<TClass>()
    {
        MvcDemoDBEntities db = new MvcDemoDBEntities();
        Dictionary<TClass, object> dict = new Dictionary<TClass, object>();
        var data = (from h in db.People
                select h).ToList();
        foreach (var item in data)
        {
            dict.Add(data, true);
        }
        return dict;
    }
