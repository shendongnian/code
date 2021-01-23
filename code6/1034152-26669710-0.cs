    public void Apply(ICollectionInstance instance)
    {
        var columnName = GetKeyName(null, instance.EntityType);
        instance.Key.Column(columnName);
    }
