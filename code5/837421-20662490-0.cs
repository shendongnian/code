    foreach (var field in fields)
        typeBuilder.DefineField(field.Key, field.Value, FieldAttributes.Public);
    var parameters = fields.ToArray();
    var ctor = typeBuilder.DefineConstructor(
        MethodAttributes.Public, CallingConventions.Standard,
        parameters.Select(p => p.Value).ToArray());
    var ctorIl = ctor.GetILGenerator();
    ctorIl.Emit(OpCodes.Ret);
    for (int i = 0; i < parameters.Length; i++)
    {
        ctor.DefineParameter(i + 1, ParameterAttributes.None, parameters[i].Key);
    }
    builtTypes[className] = typeBuilder.CreateType();
