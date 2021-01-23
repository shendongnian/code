    static void Test()
    {
        // create a dynamic assembly and module 
        AssemblyName assemblyName = new AssemblyName("HelloWorld");
        AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
        // Mark generated code as debuggable. 
        // See http://blogs.msdn.com/rmbyers/archive/2005/06/26/432922.aspx for explanation.        
        Type daType = typeof(DebuggableAttribute);
        ConstructorInfo daCtor = daType.GetConstructor(new Type[] { typeof(DebuggableAttribute.DebuggingModes) });
        CustomAttributeBuilder daBuilder = new CustomAttributeBuilder(daCtor, new object[] { 
        DebuggableAttribute.DebuggingModes.DisableOptimizations | 
        DebuggableAttribute.DebuggingModes.Default });
        assemblyBuilder.SetCustomAttribute(daBuilder);
        ModuleBuilder module = assemblyBuilder.DefineDynamicModule("HelloWorld.exe", true); // <-- pass 'true' to track debug info.
        var doc = Expression.SymbolDocument(@"Source.txt");
        // create a new type to hold our Main method 
        TypeBuilder typeBuilder = module.DefineType("HelloWorldType", TypeAttributes.Public | TypeAttributes.Class);
        // create the Main(string[] args) method 
        MethodBuilder methodbuilder = typeBuilder.DefineMethod("MyMethod", MethodAttributes.HideBySig | MethodAttributes.Static | MethodAttributes.Public, typeof(void), new Type[] { typeof(string[]) });
        // Create a local variable of type 'string', and call it 'xyz'
        var localXYZ = Expression.Variable(typeof(string), "xyz"); // Provide name for the debugger. 
        var generator = DebugInfoGenerator.CreatePdbGenerator();
        var debugInfo1 = Expression.DebugInfo(doc, 2, 1, 2, 100);
        // Emit sequence point before the IL instructions. This is start line, start col, end line, end column, 
        // Line 2: xyz = "hello"; 
        var assign = Expression.Assign(localXYZ, Expression.Constant("Hello world!"));
        // Line 3: Write(xyz); 
        MethodInfo infoWriteLine = typeof(System.Console).GetMethod("WriteLine", new Type[] { typeof(string) });
        var debugInfo2 = Expression.DebugInfo(doc, 3, 1, 3, 100);
        var write = Expression.Call(infoWriteLine, localXYZ);
        // Line 4: return; 
        var debugInfo3 = Expression.DebugInfo(doc, 4, 1, 4, 100);
        var block = Expression.Block(new ParameterExpression[] { localXYZ }, new Expression[] { debugInfo1, assign, debugInfo2, write, debugInfo3 });
        var lambda = Expression.Lambda<Action<string[]>>(block, Expression.Parameter(typeof(string[])));
        // bake it 
        lambda.CompileToMethod(methodbuilder, generator);
        Type helloWorldType = typeBuilder.CreateType();
        // This now calls the newly generated method. We can step into this and debug our emitted code!! 
        var dm = (Action<string[]>)Delegate.CreateDelegate(typeof(Action<string[]>), helloWorldType.GetMethod("MyMethod"));
        dm(new string[] { null }); // <-- step into this call 
    }
