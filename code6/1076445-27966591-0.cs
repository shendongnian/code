    // determine which method ought to be called based on `val`'s run-time type.
    // (for C# 6 and later, use the `nameof` operator instead of hard-coding method names)
    Type type = val.GetType();
    string fooName = type.IsValueType ? "FooStruct" : "FooClass";
    // bind to the generic method and supply the type argument for it:
    // (I'm assuming that your extension methods are defined in `FooMethodsClass`.)
    MethodInfo fooOpen = typeof(FooMethodsClass).GetMethod(fooName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
    MethodInfo foo = fooOpen.MakeGenericMethod(new Type[] { type });
    // invoke the generic (extension) method with `val` as the `this` argument:
    foo.Invoke(null, new object[] { val });
