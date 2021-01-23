    AssemblyName aName = new AssemblyName("SomeAssembly");
    AssemblyBuilder ab =
        AppDomain.CurrentDomain.DefineDynamicAssembly(
            aName,
            AssemblyBuilderAccess.RunAndSave);
    // For a single-module assembly, the module name is usually 
    // the assembly name plus an extension.
    ModuleBuilder mb =
        ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
    TypeBuilder tb = mb.DefineType(
        "SomeType",
         TypeAttributes.Public, typeof(Test));
