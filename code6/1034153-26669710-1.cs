    public void Apply(ICollectionInstance instance)
    {
        if (instance.EntityType != instance.ChildType)
        {
            String columnName = GetKeyName(null, instance.EntityType);
            instance.Key.Column(columnName);
        }
    }
