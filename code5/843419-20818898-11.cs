    RootClass rootObj = ...create/get the root object
    foreach(RootClass.PropertyEnum enumValue in Enum.GetValues(typeof(RootClass.PropertyEnum))
    {
        BaseClass b = rootObj.GetPropertyByEnum(enumValue);
        if (b != null) Console.Out.WriteLine("{0}.name = {1}", enumValue.ToString(), b.Name);
    }
