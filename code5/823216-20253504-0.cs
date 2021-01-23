    public static List<iml.IManDocument> ToListByReflection(this object source)
    {
        var type = source.GetType();
        var countProperty = type.GetProperty("Count");
        var itemByIndexMethod = type.GetMethod("ItemByIndex", new[] { typeof(int) });
        
        if (countProperty == null || itemByIndexMethod == null)
        {
            throw new Exception("Type does not offer required methods.");
        }
        
        var count = countProperty.GetValue(source);
        var results = new List<iManDocument>(count);
        for (int i = 1; i <= count; i++)
        {
            results.Add((iml.IManDocument)itemByIndexMethod.Invoke(source, new object[] { i });
        }
        
        return results;
    }
