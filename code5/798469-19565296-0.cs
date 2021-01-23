    Type ac;
    string cName = "ClassA";
    switch (cName)
    {
    case "ClassA":
    ac = typeof(ClassA);
    break;
    case "ClassB":
    ac = typeof(ClassB);
    break;
    default:
    ac = typeof(System.String);    
    break;
    }
    var genericListType = typeof(List<>);
    var specificListType = genericListType.MakeGenericType(ac);
    var l= Activator.CreateInstance(specificListType);
