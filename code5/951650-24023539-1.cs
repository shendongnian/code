    Microsoft.CSharp.CSharpCodeProvider provider = new Microsoft.CSharp.CSharpCodeProvider();
    System.CodeDom.Compiler.CompilerParameters parameters = new System.CodeDom.Compiler.CompilerParameters();
    parameters.GenerateInMemory = true;
    //You should add all referenced assembiles needed for the cs file here
    //parameters.ReferencedAssemblies.Add();
                
    var files = new System.IO.DirectoryInfo("").GetFiles("*.cs");
    foreach (System.IO.FileInfo file in files)
    {
        System.CodeDom.Compiler.CompilerResults result = 
            provider.CompileAssemblyFromSource(parameters, new[] { System.IO.File.ReadAllText(file.FullName) });
        object instance = result.CompiledAssembly.CreateInstance(file.Name);
        if (instance is BaseScript)
        {
            //Do processing on (BaseScript)instance
        }
    }
