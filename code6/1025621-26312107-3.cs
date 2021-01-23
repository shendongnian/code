    class Program
    {
        static void Main(string[] args)
        {
            // opcodes for pushing two arguments to the stack, adding, and returning the result.
            byte[] ilcodes = { 0x02, 0x03, 0x58, 0x2A };
            var method = CreateFromILBytes(ilcodes);
            Console.WriteLine(method(2, 3));
        }
        private static Func<int, int, int> CreateFromILBytes(byte[] bytes)
        {
            var asmName = new AssemblyName("DynamicAssembly");
            var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
            var module = asmBuilder.DefineDynamicModule("DynamicModule");
            var typeBuilder = module.DefineType("DynamicType");
            var method = typeBuilder.DefineMethod("DynamicMethod", 
                MethodAttributes.Public | MethodAttributes.Static, 
                typeof(int), 
                new[] { typeof(int), typeof(int) });
            method.CreateMethodBody(bytes, bytes.Length);
            var type = typeBuilder.CreateType();
            return (Func<int, int, int>)type.GetMethod("DynamicMethod").CreateDelegate(typeof(Func<int, int, int>));
        }
    }
