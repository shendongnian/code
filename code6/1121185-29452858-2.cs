    private object MakeTypedList(IReadOnlyList<IData> readOnlyList, DataTypes dataTypes)
    {
        var type = typeof(IData).Assembly.GetTypes()
            .Where(t => t.IsInterface && typeof (IData).IsAssignableFrom(t))
            .FirstOrDefault(t =>
            {
                var attribute = t.GetCustomAttributes(typeof(DataTypeAttribute), false)
                    .FirstOrDefault() as DataTypeAttribute;
                return attribute != null && attribute.DataType == dataTypes;
            });
        if (type == null)
            throw new InvalidEnumArgumentException("Unsupported DataType!");
        var enumerable = typeof(Enumerable)
            .GetMethod("OfType", BindingFlags.Static | BindingFlags.Public)
            .MakeGenericMethod(type)
            .Invoke(null, new object[] {readOnlyList});
        // you can omit this last step if you just want an IEnumerable<T>
        var list = typeof(Enumerable)
            .GetMethod("ToList", BindingFlags.Static | BindingFlags.Public)
            .MakeGenericMethod(type)
            .Invoke(null, new object[] { enumerable });
        return list;
    }
