        setGenerator.Emit(OpCodes.Ldarg_0);
        setGenerator.DeclareLocal(type);
        setGenerator.Emit(OpCodes.Unbox_Any, type);
        setGenerator.Emit(OpCodes.Stloc_0);
        setGenerator.Emit(OpCodes.Ldloca_S, 0);
        setGenerator.Emit(OpCodes.Ldarg_1);
        setGenerator.Emit(OpCodes.Unbox_Any, fieldInfo.FieldType);
        setGenerator.Emit(OpCodes.Stfld, fieldInfo);
        setGenerator.Emit(OpCodes.Ret);
