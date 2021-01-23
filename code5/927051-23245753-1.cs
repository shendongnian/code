    Type genericListType = typeof(List<>);
    Type[] typeArgs = new[] { instance.GetType() };
    var generic = genericListType.MakeGenericType(typeArgs);
    System.Collections.IList list = (System.Collections.IList)Activator.CreateInstance(generic);
    foreach (dynamic item in list)
    {
    //whatever
    }
