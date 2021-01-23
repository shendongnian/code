    public ContentTextMap()
    {
        ManyToOne(x => x.Content, "ContentId");
        Property(x => x.ContentId, map => {
            map.Column("ContentId");
            map.Update(true);
            map.Insert(true);
            map.NotNullable(true)
        });
        ...
