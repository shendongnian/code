    public Dictionary<object, object> GetDetails<TClass>()
    {
        MvcDemoDBEntities db = new MvcDemoDBEntities();
        Dictionary<TClass, object> dict = new Dictionary<TClass, object>();
        // etc
        return dict;
    }
