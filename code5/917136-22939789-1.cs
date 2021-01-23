    public static object ConvertList(List<object> value, Type type)
    {
       IList list = (IList)Activator.CreateInstance(type);
       foreach (var item in value)
       {
          list.Add(item);
       }
       return list;
    }
