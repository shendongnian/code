    public IEnumerable<Child> GetMethod()
    {
        List<Parent> collection = new List<Parent>();
        //// added multiple items of collection with childs.
        return collection.SelectMany(i => i.ListChild);
    }
