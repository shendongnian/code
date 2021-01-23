    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using Microsoft.CSharp;
    
    CSharpCodeProvider codeProvider = new CSharpCodeProvider();
    ICodeCompiler icc = codeProvider.CreateCompiler();
    System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
    parameters.GenerateExecutable = false;
    parameters.OutputAssembly = "My_Assembly_Day.dll";
    CompilerResults results = icc.CompileAssemblyFromSource(parameters, ".... some C# code ....");
