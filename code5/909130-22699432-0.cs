    var compUnit = new CodeCompileUnit();
    var ns = new CodeNamespace("TestNamespace");
    var iface = new CodeTypeDeclaration("ITest");
    iface.IsInterface = true;
    var mth = new CodeMemberMethod();
    mth.Name = "DoSomething";
    mth.ReturnType = new CodeTypeReference(typeof(string));
    mth.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "x"));
    iface.Members.Add(mth);
    ns.Types.Add(iface);
    compUnit.Namespaces.Add(ns);
    var csProv = new CSharpCodeProvider();
    using (var tw = File.CreateText(@"test.cs"))
    {
        var options = new CodeGeneratorOptions();
        csProv.GenerateCodeFromCompileUnit(compUnit, tw, options);
        tw.Flush();
    }
