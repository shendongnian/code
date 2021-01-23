    public ContentMap()
    {
        ...
        Bag(x => x.Texts, mapping =>
        {
            mapping.Lazy(CollectionLazy.NoLazy);
            mapping.Key(k =>
            {
                k.Column("ContentId");
            });
            ...
