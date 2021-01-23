    var getKeyImpl = type.DefineMethod(
        "GetKeyImpl",
        MethodAttributes.Private | MethodAttributes.HideBySig);
    // Preparing Reflection instances
    var knownTypes = typeof(ILLoops).GetField(
        "knownTypes",
        BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.Instance | BindingFlags.Static);
    var typeEqualsOperator = typeof(Type).GetMethod(
        "op_Equality",
        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
        null,
        new[] { typeof(Type), typeof(Type) },
        null);
    getKeyImpl.SetReturnType(typeof(int));
    getKeyImpl.SetParameters(typeof(Type));
    getKeyImpl.DefineParameter(1, ParameterAttributes.None, "obj0");
    var il = getKeyImpl.GetILGenerator();
    // Preparing locals
    il.DeclareLocal(typeof(int));
    il.DeclareLocal(typeof(int));
    il.DeclareLocal(typeof(int));
    il.DeclareLocal(typeof(bool));
    // Preparing labels
    var loopCondition = il.DefineLabel();
    var loopIterator = il.DefineLabel();
    var ifTrue = il.DefineLabel();
    var loopBody = il.DefineLabel();
    var returnLabel = il.DefineLabel();
    // Writing body
    il.Emit(OpCodes.Nop);
    il.Emit(OpCodes.Ldc_I4_M1);
    il.Emit(OpCodes.Stloc_0);
    il.Emit(OpCodes.Ldc_I4_0);
    il.Emit(OpCodes.Stloc_1);
    il.Emit(OpCodes.Br_S, loopCondition);
    il.MarkLabel(loopBody);
    il.Emit(OpCodes.Nop);
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Ldfld, knownTypes);
    il.Emit(OpCodes.Ldloc_1);
    il.Emit(OpCodes.Ldelem_Ref);
    il.Emit(OpCodes.Ldarg_1);
    il.Emit(OpCodes.Call, typeEqualsOperator);
    il.Emit(OpCodes.Ldc_I4_0);
    il.Emit(OpCodes.Ceq);
    il.Emit(OpCodes.Stloc_3);
    il.Emit(OpCodes.Ldloc_3);
    il.Emit(OpCodes.Brtrue_S, loopIterator);
    il.Emit(OpCodes.Nop);
    il.Emit(OpCodes.Ldloc_1);
    il.Emit(OpCodes.Stloc_0);
    il.Emit(OpCodes.Br_S, ifTrue);
    il.MarkLabel(loopIterator);
    il.Emit(OpCodes.Nop);
    il.Emit(OpCodes.Ldloc_1);
    il.Emit(OpCodes.Ldc_I4_1);
    il.Emit(OpCodes.Add);
    il.Emit(OpCodes.Stloc_1);
    il.MarkLabel(loopCondition);
    il.Emit(OpCodes.Ldloc_1);
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Ldfld, knownTypes);
    il.Emit(OpCodes.Ldlen);
    il.Emit(OpCodes.Conv_I4);
    il.Emit(OpCodes.Clt);
    il.Emit(OpCodes.Stloc_3);
    il.Emit(OpCodes.Ldloc_3);
    il.Emit(OpCodes.Brtrue_S, loopBody);
    il.MarkLabel(ifTrue);
    il.Emit(OpCodes.Ldloc_0);
    il.Emit(OpCodes.Stloc_2);
    il.Emit(OpCodes.Br_S, returnLabel);
    il.MarkLabel(returnLabel);
    il.Emit(OpCodes.Ldloc_2);
    il.Emit(OpCodes.Ret);
    // Finished
    return getKeyImpl;
