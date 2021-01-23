    var fb = tb.DefineField("A", typeof(int[]), FieldAttributes.Public | FieldAttributes.Static);
    var ctor = tb.DefineTypeInitializer();
    var il = ctor.GetILGenerator();
    // new int[3]
    il.Emit(OpCodes.Ldc_I4_3);
    il.Emit(OpCodes.Newarr, typeof(int));
    // array[0] = 1
    il.Emit(OpCodes.Dup);
    il.Emit(OpCodes.Ldc_I4_0);
    il.Emit(OpCodes.Ldc_I4_1);
    il.Emit(OpCodes.Stelem_I4);
    // array[1] = 2
    il.Emit(OpCodes.Dup);
    il.Emit(OpCodes.Ldc_I4_1);
    il.Emit(OpCodes.Ldc_I4_2);
    il.Emit(OpCodes.Stelem_I4);
    // arr[2] = 3
    il.Emit(OpCodes.Dup);
    il.Emit(OpCodes.Ldc_I4_2);
    il.Emit(OpCodes.Ldc_I4_3);
    il.Emit(OpCodes.Stelem_I4);
    // A = array
    il.Emit(OpCodes.Stsfld, fb);
    il.Emit(OpCodes.Ret);
