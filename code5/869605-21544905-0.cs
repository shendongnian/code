    var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" });
            parameters.GenerateExecutable = false;
            CompilerResults results = csc.CompileAssemblyFromSource(parameters,
            @"using System.Linq;
                class MyClass {
                  public void MyFunction() {
                    var q = from i in Enumerable.Range(1,100)
                              where i % 2 == 0
                              select i;
                  }
                }");
            results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
