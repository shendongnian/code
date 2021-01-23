    public IList Children
    {
        get
        {
            return new[]
            {
                new CollectionContainer("Functions", Functions),
                new CollectionContainer("Users", Users),
            };
        }
    }
