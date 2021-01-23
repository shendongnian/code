    var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("foo"), System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave);
    var mod = asm.DefineDynamicModule("mymod", true);
    var type = mod.DefineType("baz", TypeAttributes.Public);
    var method = type.DefineMethod("go", MethodAttributes.Public | MethodAttributes.Static);
    Expression fooExpression = Expression.Divide(Expression.Constant(0), Expression.Constant(0));
    var parameters = new ParameterExpression[0];
    var generator = DebugInfoGenerator.CreatePdbGenerator();
    var document = Expression.SymbolDocument(fileName: "MyDebug.txt");
    var debugInfo = Expression.DebugInfo(document, 6, 9, 6, 22);
    var expressionBlock = Expression.Block(debugInfo, fooExpression);
    var lambda = Expression.Lambda(expressionBlock, parameters);
    lambda.CompileToMethod(method, generator);
    var bakedType = type.CreateType();
    Func<int> method2 = (Func<int>)Delegate.CreateDelegate(typeof(Func<int>), bakedType.GetMethod(method.Name));
    try
    {
        int res = method2();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.StackTrace);
    }
