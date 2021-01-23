    var tb = mb.DefineType("Test", TypeAttributes.Public);
    var iface = typeof(IComparable<>).MakeGenericType(tb);
    tb.AddInterfaceImplementation(iface);
    
    var meb = tb.DefineMethod("CompareTo", MethodAttributes.Public | MethodAttributes.Virtual, typeof(int), new [] { tb } );
    var il = meb.GetILGenerator();
    il.Emit(OpCodes.Ret, 0);
    
    var type = tb.CreateType();
