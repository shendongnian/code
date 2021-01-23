    Type type = x.GetType();
    foreach (var fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
    {
        dynamic val = fieldInfo.GetValue(value);
        object obj = type.IsValueType ? Utilities.FooStruct(val) : Utilities.FooClass(val);
        fieldInfo.SetValue(x, obj);
    }
