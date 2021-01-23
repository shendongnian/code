    public static class DynamicProxyGenerator
    {
        public static object GetInstanceFor<T>(T toCopy)
        {
            Type typeOfT = typeof(T);
            
            AssemblyName assName = new AssemblyName("testAssembly");
            var assBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assName, AssemblyBuilderAccess.RunAndSave);            
            var moduleBuilder = assBuilder.DefineDynamicModule("dynamicModule", "dynamicBinder.dll");
            var typeBuilder = moduleBuilder.DefineType(typeOfT.Name + "Proxy", TypeAttributes.Public | TypeAttributes.Class);            
            FieldBuilder bindingSourceField = typeBuilder.DefineField("BindingSource", typeOfT, FieldAttributes.Public);            
                        
            foreach (FieldInfo toCopyField in typeOfT.GetFields()) 
            {
                PropertyBuilder propBuilder = typeBuilder.DefineProperty(toCopyField.Name, System.Reflection.PropertyAttributes.None, toCopyField.FieldType, null);                             
                
                MethodBuilder getter = typeBuilder.DefineMethod("get_" + toCopyField.Name,  MethodAttributes.Public, toCopyField.FieldType, Type.EmptyTypes);                
                ILGenerator getIL = getter.GetILGenerator();
                getIL.Emit(OpCodes.Ldarg_0);
                getIL.Emit(OpCodes.Ldfld, bindingSourceField);
                getIL.Emit(OpCodes.Ldfld, toCopyField);
                getIL.Emit(OpCodes.Ret);
                propBuilder.SetGetMethod(getter);
                MethodBuilder setter = typeBuilder.DefineMethod("set_" + toCopyField.Name,  MethodAttributes.Public, null, new Type[] { toCopyField.FieldType });
                ILGenerator setIL = setter.GetILGenerator();
                setIL.Emit(OpCodes.Ldarg_0);
                setIL.Emit(OpCodes.Ldfld, bindingSourceField);
                setIL.Emit(OpCodes.Ldarg_1);                
                setIL.Emit(OpCodes.Stfld, toCopyField);
                setIL.Emit(OpCodes.Ret);
                propBuilder.SetSetMethod(setter);                
            }
             
            Type constructedType = typeBuilder.CreateType();
            dynamic instance = Activator.CreateInstance(constructedType);
            instance.BindingSource = toCopy;
            return instance;
        }
    }  
