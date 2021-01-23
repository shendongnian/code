    public static void PopulateCollections()
    {
        var fields = typeof(CollectionsClass).GetFields();
        foreach (var fieldInfo in fields)
        {
            dynamic field = fieldInfo.GetValue(null);
            Populate(field, 0, 1000);
        }
    }
