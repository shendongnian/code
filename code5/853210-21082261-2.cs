    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly;
            using (MemoryStream assemblyStream = new MemoryStream(File.ReadAllBytes("TargetDLL.dll")))
            {
                // 1. Get the reference to third-party method.
                AssemblyDefinition assemblyDef = AssemblyDefinition.ReadAssembly(assemblyStream);
                TypeDefinition targetDLLType = assemblyDef.Modules[0].GetType("TargetDLL.Foo");
                MethodDefinition barMethod = targetDLLType.Methods[0];
                // 2. Let's see what Foo.Bar returns...
                assembly = Assembly.Load(assemblyStream.ToArray());
                Console.WriteLine(CallMethod<int>(assembly.GetType("TargetDLL.Foo"), "Bar"));
                // 3. Boot up the IL processor.
                var processor = barMethod.Body.GetILProcessor();
                // 4 View the unmodified IL.
                Console.WriteLine("Original code");
                PrintIL(processor);
                // 5. Modify the code.
                // 5.a Clear the method of all IL.
                processor.Body.Instructions.Clear();
                // 5.b Inject our custom return value.
                processor.Emit(OpCodes.Ldc_I4, 1337);
                processor.Emit(OpCodes.Ret);
                // 6. And how does it look now?
                Console.WriteLine();
                Console.WriteLine("New code");
                PrintIL(processor);
                // 7. Save it.
                assemblyDef.Write(assemblyStream);
                assembly = Assembly.Load(assemblyStream.ToArray());
                // 8. Result value.
                Console.WriteLine(CallMethod<int>(assembly.GetType("TargetDLL.Foo"), "Bar"));
            }
            Console.WriteLine("END");
            Console.ReadKey(true);
        }
        static void PrintIL(ILProcessor processor)
        {
            foreach (var instruction in processor.Body.Instructions)
            {
                Console.WriteLine(instruction);
            }
        }
        static T CallMethod<T>(Type type, string method)
        {
            return (T)type.InvokeMember("Bar", BindingFlags.Static | BindingFlags.InvokeMethod | BindingFlags.Public, null, null,
                null);
        }
    }
