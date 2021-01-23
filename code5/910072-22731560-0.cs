    var opType = typeof(OrderPersisted);
    var myType = typeof (EventHandlerBase<>).MakeGenericType(opType);
    var myExpectedTypes = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(x => x.IsSubclassOf(myType))
        .ToArray();
