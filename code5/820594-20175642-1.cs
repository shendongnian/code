    TypeBuilder parentBuilder = moduleBuilder.DefineType("Parent", TypeAttributes.Public);
    TypeBuilder childBuilder = parentBuilder.DefineNestedType("Child", TypeAttributes.NestedPublic);
    PropertyBuilder propertyBuilder = parentBuilder.DefineProperty("MyChild", PropertyAttributes.None, childBuilder, null);
    // Define field
    FieldBuilder fieldBuilder = parentBuilder.DefineField("myChild", childBuilder, FieldAttributes.Private);
    // Define "getter" for MyChild property
    MethodBuilder getterBuilder = parentBuilder.DefineMethod("get_MyChild",
                                        MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                                        childBuilder,
                                        Type.EmptyTypes);
    ILGenerator getterIL = getterBuilder.GetILGenerator();
    getterIL.Emit(OpCodes.Ldarg_0);
    getterIL.Emit(OpCodes.Ldfld, fieldBuilder);
    getterIL.Emit(OpCodes.Ret);
    // Define "setter" for MyChild property
    MethodBuilder setterBuilder = parentBuilder.DefineMethod("set_MyChild", 
                                        MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                                        null,
                                        new Type[] { childBuilder });
    ILGenerator setterIL = setterBuilder.GetILGenerator();
    setterIL.Emit(OpCodes.Ldarg_0);
    setterIL.Emit(OpCodes.Ldarg_1);
    setterIL.Emit(OpCodes.Stfld, fieldBuilder);
    setterIL.Emit(OpCodes.Ret);
    propertyBuilder.SetGetMethod(getterBuilder);
    propertyBuilder.SetSetMethod(setterBuilder);
