        string source = "public class Description" +
                        "{" +
                        "   public string DescriptionText { get; set; }" +
                        "   public string Country { get; set; }" +
                        "}";
        CSharpCodeProvider codeProvider = new CSharpCodeProvider();
        System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
        parameters.GenerateExecutable = false;
        parameters.GenerateInMemory = true;
        CompilerResults result = codeProvider.CompileAssemblyFromSource(parameters, source);
        if (!result.Errors.HasErrors)
        {
            Type type = result.CompiledAssembly.GetType("Description");
            var instance = Activator.CreateInstance(type);
        }
