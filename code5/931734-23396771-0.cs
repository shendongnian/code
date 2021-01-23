    var genericMethod = typeof(Foo).GetMethod("GenericSetActive",
                                              BindingFlags.NonPublic |
                                              BindingFlags.Static);
    var concreteMethod = genericMethod.MakeGenericMethod(type);
    var actionInstance = Delegate.CreateDelegate(action, concreteMethod);
