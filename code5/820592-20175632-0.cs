        public static Type BuildType() {
            AssemblyName newAssembly = new AssemblyName("myAssembly");
            //AppDomain appDomain = System.Threading.Thread.GetDomain();
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain
                .DefineDynamicAssembly(
                newAssembly, 
                AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder moduleBuilder = assemblyBuilder
                .DefineDynamicModule(newAssembly.Name, newAssembly.Name + ".dll");
            TypeBuilder parentBuilder = moduleBuilder.DefineType(
                "Parent", TypeAttributes.Public);
            var ctor0 = parentBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                Type.EmptyTypes);
            ILGenerator ctor0IL = ctor0.GetILGenerator();
            // For a constructor, argument zero is a reference to the new 
            // instance. Push it on the stack before pushing the default 
            // value on the stack, then call constructor ctor1.
            ctor0IL.Emit(OpCodes.Ldarg_0);
            ctor0IL.Emit(OpCodes.Ldc_I4_S, 42);
            ctor0IL.Emit(OpCodes.Call, ctor0);
            ctor0IL.Emit(OpCodes.Ret);
            //TypeBuilder childBuilder = parentBuilder.DefineNestedType("Child");
            //var chType = childBuilder.CreateType();
            parentBuilder.DefineProperty(
                "MyProperty",
                PropertyAttributes.HasDefault,
                typeof(string),
                //childBuilder.CreateType(),
                null);
            var type = parentBuilder.CreateType();
            assemblyBuilder.Save(newAssembly.Name + ".dll");
            return type;
        }
