    Type valueType = Type.GetType("System.Int32");
    Type listType = typeof(List<>).MakeGenericType(valueType);
    IList list = (IList) Activator.CreateInstance(listType);
    // now use Reflection to find the Parse() method on the valueType. This will not be possible for all types
    string valueToAdd = "5";
    MethodInfo parse = valueType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static);
    object value = parse.Invoke(null, new object[] { valueToAdd });
    list.Add(value);
