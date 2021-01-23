    public static Type CreateAnonymousType<TFieldA, TFieldB>(string fieldNameA, string fieldNameB)
    {
        AssemblyName dynamicAssemblyName = new AssemblyName("TempAssembly");
        AssemblyBuilder dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(dynamicAssemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder dynamicModule = dynamicAssembly.DefineDynamicModule("TempAssembly");
        TypeBuilder dynamicAnonymousType = dynamicModule.DefineType("AnonymousType", TypeAttributes.Public);
        dynamicAnonymousType.DefineField(fieldNameA, typeof(TFieldA), FieldAttributes.Public);
        dynamicAnonymousType.DefineField(fieldNameB, typeof(TFieldB), FieldAttributes.Public);
        return dynamicAnonymousType.CreateType();
    }
