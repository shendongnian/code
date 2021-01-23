    // Declaring the method
    var getKeyImpl = type.DefineMethod(
        "GetKeyImpl",
        MethodAttributes.Private | MethodAttributes.HideBySig);
    // Finding dependencies via reflection
    var knownTypes = typeof(ILLoops).GetField(
        "knownTypes",
        BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.Static | BindingFlags.Instance);
    var typeEqualsOperator = typeof(Type).GetMethod(
        "op_Equality",
        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
        null,
        new[] { typeof(Type), typeof(Type) },
        null);
    // Setting return type
    getKeyImpl.SetReturnType(typeof(int));
    // Adding parameters
    getKeyImpl.SetParameters(typeof(Type));
    getKeyImpl.DefineParameter(1, ParameterAttributes.None, "obj0");
    var il = getKeyImpl.GetILGenerator();
    // Preparing locals
    il.DeclareLocal(typeof(int));
    il.DeclareLocal(typeof(int));
    // Preparing labels
    var loopCondition = il.DefineLabel();
    var loopIterator = il.DefineLabel();
    var returnLabel = il.DefineLabel();
    var loopBody = il.DefineLabel();
    // Writing body
    // answer = -1
    il.Emit(OpCodes.Ldc_I4_M1);
    il.Emit(OpCodes.Stloc_0);
    // i = 0
    il.Emit(OpCodes.Ldc_I4_0);
    il.Emit(OpCodes.Stloc_1);
    // jump to loop condition
    il.Emit(OpCodes.Br_S, loopCondition);
    // begin loop body
    il.MarkLabel(loopBody);
    // if (obj0 != knownTypes[i]) continue
    il.Emit(OpCodes.Ldarg_0);  // omit if 'knownTypes' is static
    il.Emit(OpCodes.Ldfld, knownTypes);  // use 'Ldsfld' if 'knownTypes' is static
    il.Emit(OpCodes.Ldloc_1);
    il.Emit(OpCodes.Ldelem_Ref);
    il.Emit(OpCodes.Ldarg_1);  // use 'Ldarg_0' if 'knownTypes' is static
    il.Emit(OpCodes.Call, typeEqualsOperator);
    il.Emit(OpCodes.Brfalse_S, loopIterator);
    // answer = i; jump to return
    il.Emit(OpCodes.Ldloc_1);
    il.Emit(OpCodes.Stloc_0);
    il.Emit(OpCodes.Br_S, returnLabel);
    // begin loop iterator
    il.MarkLabel(loopIterator);
    // i = i + 1
    il.Emit(OpCodes.Ldloc_1);
    il.Emit(OpCodes.Ldc_I4_1);
    il.Emit(OpCodes.Add);
    il.Emit(OpCodes.Stloc_1);
    // begin loop condition
    il.MarkLabel(loopCondition);
    // if (i < knownTypes.Length) jump to loop body
    il.Emit(OpCodes.Ldloc_1);
    il.Emit(OpCodes.Ldarg_0);  // omit if 'knownTypes' is static
    il.Emit(OpCodes.Ldfld, knownTypes);  // use 'Ldsfld' if 'knownTypes' is static
    il.Emit(OpCodes.Ldlen);
    il.Emit(OpCodes.Conv_I4);
    il.Emit(OpCodes.Blt_S, loopBody);
    // return answer
    il.MarkLabel(returnLabel);
    il.Emit(OpCodes.Ldloc_0);
    il.Emit(OpCodes.Ret);
    // Finished
    return getKeyImpl;
