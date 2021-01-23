    ilGen.Emit(OpCodes.Ldstr, "a");
    
    ilGen.BeginExceptionBlock();
    ilGen.BeginCatchBlock(typeof(Exception));
    ilGen.EndExceptionBlock();
    
    ilGen.Emit(OpCodes.Pop);
    ilGen.Emit(OpCodes.Ret);
