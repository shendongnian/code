    var label1 = il.DefineLabel();
    var label2 = il.DefineLabel();
    il.Emit(OpCodes.Ldarg_S, 0); // object
    il.Emit(OpCodes.Isinst, typeof(DateTime)); // boxed DateTime
    il.Emit(OpCodes.Dup); // boxed DateTime, boxed DateTime
    il.Emit(OpCodes.Brfalse_S, label1); // boxed DateTime
    il.Emit(OpCodes.Unbox_Any, typeof(DateTime)); // unboxed DateTime
    il.Emit(OpCodes.Ldc_I4_1); // unboxed DateTime, int
    il.Emit(OpCodes.Call, typeof(DateTime).GetMethod("SpecifyKind")); // unboxed DateTime
    il.Emit(OpCodes.Newobj, typeof(DateTime?).GetConstructor(new[] { typeof(DateTime) })); // unboxed DateTime?
    il.Emit(OpCodes.Br_S, label2);
    il.MarkLabel(label1); // boxed DateTime (known to be null)
    il.Emit(OpCodes.Unbox_Any, typeof(DateTime?)); // unboxed DateTime?
    il.MarkLabel(label2); // unboxed DateTime?
    il.Emit(OpCodes.Ret);
