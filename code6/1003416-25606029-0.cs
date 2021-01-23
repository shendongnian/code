    var ctorIl = ctor.GetILGenerator();
    ctorIl.Emit(OpCodes.Ldarg_0); // show where to load the following string
    ctorIl.Emit(OpCodes.Ldstr, "Partner");
    ctorIl.Emit(OpCodes.Call, parentCtorGeneric1);
    ctorIl.Emit(OpCodes.Ret);
