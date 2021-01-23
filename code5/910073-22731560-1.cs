    var opType = typeof(OrderPersisted);//Your choice
    var myType = typeof (EventHandlerBase<>).MakeGenericType(opType);
    var myExpectedTypes = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(x => x.IsSubclassOf(myType))
        .ToArray();
