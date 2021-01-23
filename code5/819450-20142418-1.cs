    public Dictionary<object, object> GetDetails<TClass>()
    {
        MvcDemoDBEntities db = new MvcDemoDBEntities();
        Dictionary<TClass, object> dict = new Dictionary<TClass, object>();
        //to add to the dictionary:
        dict.Add(item, _object); //where item is of type TClass
        return dict;
    }
