    var tb = mb.DefineType("Test", TypeAttributes.Public);
    var iface = typeof(IComparable<>).MakeGenericType(tb);
    tb.AddInterfaceImplementation(iface);
    
    var meb = tb.DefineMethod("CompareTo", MethodAttributes.Public | MethodAttributes.Virtual, typeof(int), new [] { tb } );
    var il = meb.GetILGenerator();
    il.ThrowException(typeof(Exception));
    
    var type = tb.CreateType();
