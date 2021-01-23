    object result;
    string string_1 = "true";
    string string_2 = "System.Boolean";
    var targetType = Type.GetType(string_2);
    if (typeof(IConvertible).IsAssignableFrom(targetType))
    {
        result = Convert.ChangeType(string_1, targetType);
    }
    else
    {
        var parseMethod = targetType.GetMethod("Parse", new[] {typeof (string)});
        if (parseMethod != null)
            result = parseMethod.Invoke(null, new object[] { string_1 });
    }
