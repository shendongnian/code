    Type taskType = typeof(Task);
    FieldInfo continuationField = taskType.GetField("m_continuationObject", BindingFlags.Instance | BindingFlags.NonPublic);
    Type safeScenario = taskType.GetNestedType("SetOnInvokeMres", BindingFlags.NonPublic);
    if (continuationField != null && continuationField.FieldType == typeof(object) && safeScenario != null)
    {
        var method = new DynamicMethod("IsSyncSafe", typeof(bool), new[] { typeof(Task) }, typeof(Task), true);
        var il = method.GetILGenerator();
        var hasContinuation = il.DefineLabel();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, continuationField);
        Label nonNull = il.DefineLabel(), goodReturn = il.DefineLabel();
        // check if null
        il.Emit(OpCodes.Brtrue_S, nonNull);
        il.MarkLabel(goodReturn);
        il.Emit(OpCodes.Ldc_I4_1);
        il.Emit(OpCodes.Ret);
        // check if is a SetOnInvokeMres - if so, we're OK
        il.MarkLabel(nonNull);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, continuationField);
        il.Emit(OpCodes.Isinst, safeScenario);
        il.Emit(OpCodes.Brtrue_S, goodReturn);
        il.Emit(OpCodes.Ldc_I4_0);
        il.Emit(OpCodes.Ret);
        IsSyncSafe = (Func<Task, bool>)method.CreateDelegate(typeof(Func<Task, bool>));
