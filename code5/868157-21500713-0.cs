    // create a field to hold the dynamic delegate
    var fieldBuilder = _typeBuilder.DefineField(
      "<>delegate_field",
      delegateToInvoke.GetType(),
      FieldAttributes.Private);
    // remember to set it later when we create a new instance
    _fieldsToSet.Add(new KeyValuePair<FieldInfo, object>(fieldBuilder, delegateToInvoke));
    var il = methodBuilder.GetILGenerator();
    // push the delegate onto the stack
    il.Emit(OpCodes.Ldarg_0);
    // by loading the field
    il.Emit(OpCodes.Ldfld, fieldBuilder);
    // if the delegate has a target, that means the first argument is really a pointer to a "this"
    // object/closure, and we don't want to forward it. Thus, we skip it and continue as if it
    // wasn't there.
    if (delegateToInvoke.Target != null)
    {
      parameters = parameters.Skip(1).ToArray();
    }
    // push each argument onto the stack (thus "forwarding" the arguments to the delegate).
    for (int i = 0; i < parameters.Length; i++)
    {
      il.Emit(OpCodes.Ldarg, i + 1);
    }
    // call the delegate and return
    il.Emit(OpCodes.Callvirt, delegateToInvoke.GetType().GetMethod("Invoke"));
    il.Emit(OpCodes.Ret);
