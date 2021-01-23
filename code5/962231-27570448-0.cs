    private static string GetTypeName(Type type)
    {
        string name = type.FullName;
        if (type.IsGenericType)
        {
            // Format the generic type name to something like: Generic{System.Int32,System.String}
            Type genericType = type.GetGenericTypeDefinition();
            Type[] genericArguments = type.GetGenericArguments();
            string genericTypeName = genericType.FullName;
            // Trim the generic parameter counts from the name
            genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
            string[] argumentTypeNames = genericArguments.Select(t => GetTypeName(t)).ToArray();
            name = String.Format(CultureInfo.InvariantCulture, "{0}{{{1}}}", genericTypeName, String.Join(",", argumentTypeNames));
        }
        if (type.IsNested)
        {
            // Changing the nested type name from OuterType+InnerType to OuterType.InnerType to match the XML documentation syntax.
            name = name.Replace("+", ".");
        }
        return name;
    }
