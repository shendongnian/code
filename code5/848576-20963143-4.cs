    // create the delegate type so we can find the appropriate constructor
    var delegateType = typeof(Action<>).MakeGenericType(typeParamOne);
    // work out concrete type for calling the generic MyMethod
    var myMethodType = typeof(MyClass)
        .GetMethod("MyMethod")
        .MakeGenericMethod(typeParamOne);
    // create an instance of the delegate type wrapping MyMethod so we can pass it to the constructor
    var delegateInstance = Delegate.CreateDelegate(delegateType, myMethodType);
    var type = typeof(SomeFrameworkType<,>);
    var constructed = type.MakeGenericType(typeParamOne, typeParamTwo);
    var instance = Activator.CreateInstance(constructed, delegateInstance);
