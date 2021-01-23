    public static object ConvertList(List<object> value, Type type)
    {
       var d1 = typeof(List<>);
       Type[] typeArgs = { type };
       var makeme = d1.MakeGenericType(typeArgs);
       IList list = (IList)Activator.CreateInstance(makeme);
       foreach (var item in value)
       {
          list.Add(item);
       }
       return list;
    }
