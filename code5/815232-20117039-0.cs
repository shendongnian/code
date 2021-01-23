    static void Main(string[] args)
    {
        // defines references
        List<string> references = new List<string>();
    
        // get a reference to the mscorlib you want
        var mscorlib_2_x86 = Path.Combine(
                             Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                             @"Microsoft.NET\Framework\v2.0.50727\mscorlib.dll");
        references.Add(mscorlib_2_x86);
    
        // ... add other references (System.dll, etc.)
    
        var provider = new CSharpCodeProvider(
                       new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
        var parameters = new CompilerParameters(references.ToArray(), "program.exe");
        parameters.GenerateExecutable = true;
        
        // instruct the compiler not to use the default mscorlib
        parameters.CompilerOptions = "/nostdlib";              
        var results = provider.CompileAssemblyFromSource(parameters,
            @"using System;
                    
            class Program
            {
                static void Main(string[] args)
                {
                    Console.WriteLine(""Hello world from CLR version: "" + Environment.Version);
                }
            }");
    }
