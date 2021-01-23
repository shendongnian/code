    // make delegate and find length of IL:
    Func<int, int> f = x => x * x;
    Console.WriteLine(f.Method.GetMethodBody().GetILAsByteArray().Length);
    // make expression tree
    Expression<Func<int, int>> e = x => x * x;
      
    // one approach to finding IL length
    var methInf = e.Compile().Method;
    var owner = (System.Reflection.Emit.DynamicMethod)methInf.GetType().GetField("m_owner", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(methInf);
    Console.WriteLine(owner.GetILGenerator().ILOffset);
    // another approach to finding IL length
    var an = new System.Reflection.AssemblyName("myTest");
    var assem = AppDomain.CurrentDomain.DefineDynamicAssembly(an, System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave);
    var module = assem.DefineDynamicModule("myTest");
    var type = module.DefineType("myClass");
    var methBuilder = type.DefineMethod("myMeth", System.Reflection.MethodAttributes.Static);
    e.CompileToMethod(methBuilder);
    Console.WriteLine(methBuilder.GetILGenerator().ILOffset);
