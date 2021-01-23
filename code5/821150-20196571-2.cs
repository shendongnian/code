    using System;
    using System.CodeDom.Compiler;
    //...
    string myString = "20";
    CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
    ICodeCompiler icc = codeProvider.CreateCompiler();
    System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
    parameters.GenerateExecutable = false;
    parameters.GenerateInMemory = true;
    CompilerResults results = icc.CompileAssemblyFromSource(
        parameters,
        string.Format(@"
    namespace N{{
    public static class C{{
    public static string M(){{
    return ({0} + {1}).ToString();
    }}}}}}",
            myString,
            "2"));
    myString = results
        .CompiledAssembly
        .GetType("N.C")
        .GetMethod("M")
        .Invoke(null, null)
        .ToString();
