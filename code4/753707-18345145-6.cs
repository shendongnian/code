    public static class DynamicInterfaceFactory
    {
        public static Type GenerateCombinedInterfaceType(Type type1, Type type2)
        {            
            if (!type1.IsInterface)
                throw new ArgumentException("Type type1 is not an interface", "type1");
    
            if (!type2.IsInterface)
                throw new ArgumentException("Type type2 is not an interface", "type2");
    
            //////////////////////////////////////////////
            // Module and Assembly Creation
    
            var orginalAssemblyName = type1.Assembly.GetName().Name;
    
            ModuleBuilder moduleBuilder;
    
            var tempAssemblyName = new AssemblyName(Guid.NewGuid().ToString());
    
            var dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
                tempAssemblyName,
                System.Reflection.Emit.AssemblyBuilderAccess.RunAndCollect);
    
            moduleBuilder = dynamicAssembly.DefineDynamicModule(
                tempAssemblyName.Name,
                tempAssemblyName + ".dll");
    
    
            var assemblyName = moduleBuilder.Assembly.GetName();
    
            //////////////////////////////////////////////
    
            //////////////////////////////////////////////
            // Create the TypeBuilder
    
            var typeBuilder = moduleBuilder.DefineType(
                type1.FullName,
                TypeAttributes.Public | TypeAttributes.Interface | TypeAttributes.Abstract);
    
            typeBuilder.AddInterfaceImplementation(type1);
            typeBuilder.AddInterfaceImplementation(type2);
    
            //////////////////////////////////////////////
    
            //////////////////////////////////////////////
            // Create and return the defined type
    
            Type newType = typeBuilder.CreateType();
    
            return newType;
    
            //////////////////////////////////////////////
        }
    }
