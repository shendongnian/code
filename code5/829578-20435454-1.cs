    CSharpCodeProvider codeProvider = new CSharpCodeProvider();
    System.CodeDom.Compiler.CompilerParameters param = new CompilerParameters();
    param.GenerateExecutable = false;
    param.GenerateInMemory = true;
    param.ReferencedAssemblies.Add("System.Runtime.Serialization.dll");
    param.ReferencedAssemblies.Add("System.ServiceModel.dll");
    param.ReferencedAssemblies.Add("System.dll");
    param.ReferencedAssemblies.Add("ConsoleApplication.exe");
    CompilerResults result = codeProvider.CompileAssemblyFromSource(param, source.ToString());
