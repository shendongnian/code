        FieldBuilder field = ivTypeBld.DefineField("_value", typeof(string), FieldAttributes.Public);
        MethodBuilder toStringMethod = ivTypeBld.DefineMethod("ToString",
            MethodAttributes.Public
            | MethodAttributes.HideBySig
            | MethodAttributes.NewSlot
            | MethodAttributes.Virtual
            | MethodAttributes.Final,
            CallingConventions.HasThis,
            typeof(string), 
            Type.EmptyTypes);
        ILGenerator il = toStringMethod.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, field);
        il.Emit(OpCodes.Ret);
        ivTypeBld.DefineMethodOverride(toStringMethod, typeof(object).GetMethod("ToString"));
