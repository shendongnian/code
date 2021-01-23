    public List<SomeObject> CreateCollection()
    {
        // You may want to initialize this.Collection somehere, ie: here
        this.Collection.Add(new SomeObject
        {
            // This allows you to initialize the properties
            Collection = this.Collection
        });
    }
