    private MemoryMappedViewAccessor _acc;
    // ...
    var viewAccessor = file.CreateViewAccessor(0, 123 * 1000);
    _acc = viewAccessor; 
    // ...
    ilGen.Emit(OpCodes.Ldarg_0);
    ilGen.Emit(OpCodes.Ldfld, accField);
    ilGen.Emit(OpCodes.Ldc_I4, 3214);
    ilGen.Emit(OpCodes.Conv_I8);
    ilGen.Emit(OpCodes.Callvirt, readMethod);
    ilGen.Emit(OpCodes.Ret);
