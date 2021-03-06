    class DynamicExtension<T>
    {
        public K ExtendWith<K>()
        { 
            var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Assembly"), AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("Module");
            var type = module.DefineType("Class", TypeAttributes.Public, typeof(T));
            type.AddInterfaceImplementation(typeof(K));
            foreach (var v in typeof(K).GetProperties())
            {
                var field = type.DefineField("_" + v.Name.ToLower(), v.PropertyType, FieldAttributes.Private);
                var property = type.DefineProperty(v.Name, PropertyAttributes.None, v.PropertyType, new Type[0]);
                var getter = type.DefineMethod("get_" + v.Name, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.Virtual, v.PropertyType, new Type[0]);
                var setter = type.DefineMethod("set_" + v.Name, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.Virtual, null, new Type[] { v.PropertyType });
                var getGenerator = getter.GetILGenerator();
                var setGenerator = setter.GetILGenerator();
                getGenerator.Emit(OpCodes.Ldarg_0);
                getGenerator.Emit(OpCodes.Ldfld, field);
                getGenerator.Emit(OpCodes.Ret);
                setGenerator.Emit(OpCodes.Ldarg_0);
                setGenerator.Emit(OpCodes.Ldarg_1);
                setGenerator.Emit(OpCodes.Stfld, field);
                setGenerator.Emit(OpCodes.Ret);
                
                property.SetGetMethod(getter);
                property.SetSetMethod(setter);
                type.DefineMethodOverride(getter, v.GetGetMethod());
                type.DefineMethodOverride(setter, v.GetSetMethod());
            }
            return (K)Activator.CreateInstance(type.CreateType());
        }
    }
