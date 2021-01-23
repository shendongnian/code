    internal static class DyanamicTypeBuilder
    {
        private static readonly AssemblyBuilder _assembly;
        private static readonly ModuleBuilder _module;
        private static readonly object _syncBlk = new object();
        static DyanamicTypeBuilder()
        {
            _assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("MyDyanmicAssembly"), AssemblyBuilderAccess.Run);
            _module = _assembly.DefineDynamicModule("MyDynamicModule");
        }
        private static TypeBuilder CreateTypeBuilder(string typeName)
        {
            lock (_syncBlk)
            {
                var typeBuilder = _module.DefineType(typeName, TypeAttributes.Public);
                typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
                return typeBuilder;
            }
        }
    }
