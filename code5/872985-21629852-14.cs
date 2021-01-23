    TypeBuilder type = /* ... */;
    FieldInfo knownFields = /* ... */;
    // Finding dependencies via reflection
    var baseMethod = type.BaseType.GetMethod(
        "GetKeyImpl",
        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    var typeEqualsOperator = typeof(Type).GetMethod(
        "op_Equality",
        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
        null,
        new[] { typeof(Type), typeof(Type) },
        null);
    // Declaring the method
    var getKeyImpl = type.DefineMethod(
        baseMethod.Name,
        baseMethod.Attributes & ~(MethodAttributes.Abstract |
                                  MethodAttributes.NewSlot));
    // Setting return type
    getKeyImpl.SetReturnType(typeof(int));
    // Adding parameters
    getKeyImpl.SetParameters(typeof(Type));
    getKeyImpl.DefineParameter(1, ParameterAttributes.None, "obj0");
    // Override the base method
    type.DefineMethodOverride(getKeyImpl, baseMethod);
    var il = getKeyImpl.GetILGenerator();
    // Preparing locals
    var answer = il.DeclareLocal(typeof(int));
    var i = il.DeclareLocal(typeof(int));
    // Preparing labels
    var loopCondition = il.DefineLabel();
    var loopIterator = il.DefineLabel();
    var returnLabel = il.DefineLabel();
    var loopBody = il.DefineLabel();
    // Writing body
    // answer = -1
    il.Emit(OpCodes.Ldc_I4_M1);
    il.Emit(OpCodes.Stloc, answer);
    // i = 0
    il.Emit(OpCodes.Ldc_I4_0);
    il.Emit(OpCodes.Stloc, i);
    // jump to loop condition
    il.Emit(OpCodes.Br_S, loopCondition);
    // begin loop body
    il.MarkLabel(loopBody);
    // if (obj0 != knownTypes[i]) continue
    il.Emit(OpCodes.Ldarg_0); // omit if 'knownTypes' is static
    il.Emit(OpCodes.Ldfld, knownTypes); // use 'Ldsfld' if 'knownTypes' is static
    il.Emit(OpCodes.Ldloc, i);
    il.Emit(OpCodes.Ldelem_Ref);
    il.Emit(OpCodes.Ldarg_1); // use 'Ldarg_0' if 'knownTypes' is static
    il.Emit(OpCodes.Call, typeEqualsOperator);
    il.Emit(OpCodes.Brfalse_S, loopIterator);
    // answer = i; jump to return
    il.Emit(OpCodes.Ldloc, i);
    il.Emit(OpCodes.Stloc, answer);
    il.Emit(OpCodes.Br_S, returnLabel);
    // begin loop iterator
    il.MarkLabel(loopIterator);
    // i = i + 1
    il.Emit(OpCodes.Ldloc, i);
    il.Emit(OpCodes.Ldc_I4_1);
    il.Emit(OpCodes.Add);
    il.Emit(OpCodes.Stloc, i);
    // begin loop condition
    il.MarkLabel(loopCondition);
    // if (i < knownTypes.Length) jump to loop body
    il.Emit(OpCodes.Ldloc, i);
    il.Emit(OpCodes.Ldarg_0); // omit if 'knownTypes' is static
    il.Emit(OpCodes.Ldfld, knownTypes); // use 'Ldsfld' if 'knownTypes' is static
    il.Emit(OpCodes.Ldlen);
    il.Emit(OpCodes.Conv_I4);
    il.Emit(OpCodes.Blt_S, loopBody);
    // return answer
    il.MarkLabel(returnLabel);
    il.Emit(OpCodes.Ldloc, answer);
    il.Emit(OpCodes.Ret);
    // Finished!
 
