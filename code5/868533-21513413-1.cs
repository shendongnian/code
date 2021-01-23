    var argument = new Type[] { typeof(myType) };
    var listType = typeof(List<>); 
    var genericType = listType.MakeGenericType(argument); // create generic type
    var instance = Activator.CreateInstance(genericType);  // create generic List instance
    var method = listType.GetMethod("Add"); // get Add method
    method.Invoke(instance, new [] { argument }); // invoke add method 
