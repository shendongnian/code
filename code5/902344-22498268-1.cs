    // create an object of a known type
    var someObject = Activator.CreateInstance(derivedClassType);
    // get the base class of the known type
    var baseType = derivedClassType.BaseType;
    // create a type of a generic list
    Type openListType = typeof(List<>);
    // set the item type of the generic list type to the base stype
    Type baseTypeListType = openListType.MakeGenericType(baseType);
    // create an instance of the list
    dynamic baseTypeList = Activator.CreateInstance(baseTypeListType);
    // add 
    baseTypeList.Add(someObject);
