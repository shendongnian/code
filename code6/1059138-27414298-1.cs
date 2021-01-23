    public static object DynamicProjection(object input, IEnumerable<string> properties)
    {
        var type = input.GetType();
        dynamic dObject = new ExpandoObject();
        var dDict = dObject as IDictionary<string, object>;
        foreach (var p in properties)
        {
            var field = type.GetField(p);
            if (field != null)
                dDict [p] = field.GetValue(input);
            var prop = type.GetProperty(p);
            if (prop != null && prop.GetIndexParameters().Length == 0)
                dDict[p] = prop.GetValue(input, null);
        }
        return dObject;
    }
