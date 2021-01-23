    public List<SomeObject> CreateCollection()
    {
        this.Collection = new List<SomeObject>(); // this creates a new list - the default if you just define a list but don't create it is for it to remain null
        this.Collection.Add(new SomeObject()
        {
            // whatever
        });
    }
