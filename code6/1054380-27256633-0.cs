    var ilgen = constuctor.GetILGenerator();
    ilgen.Emit(OpCodes.Ldarg_0); // this
    ilgen.Emit(OpCodes.Ldarg_1); // 1st parameter
    ilgen.Emit(OpCodes.Call, baseCtor);
    ilgen.Emit(OpCodes.Ret);
