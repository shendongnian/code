    DynamicMethod dm = new DynamicMethod("MyCtor", type, Type.EmptyTypes, typeof(ClassFactory).Module, true);
    ILGenerator ilgen = dm.GetILGenerator();
    ilgen.Emit(OpCodes.Nop);
    ilgen.Emit(OpCodes.Newobj, ci);
    ilgen.Emit(OpCodes.Ret);
    CtorDelegate del = ((CtorDelegate) dm.CreateDelegate(typeof(CtorDelegate)));
    return del.Invoke(); // could cache del in a dictionary
