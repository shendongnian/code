    object obj = new List<int> { 1, 2, 3 };
    Type type = obj.GetType();
    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
    {
        MethodInfo method = type.GetMethod("AsReadOnly");
        IList typed = method.Invoke(obj, null) as IList;
        IEnumerable<object> genericAgain = typed.OfType<object>();
        IEnumerable<string> strings = genericAgain.Select(x => x.ToString());
        List<string> done = strings.ToList();
    }
