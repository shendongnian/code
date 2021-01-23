    /// <summary>
    /// 
    /// </summary>
    /// <param name="scriptString">My string i want to compile</param>
    /// <param name="lastCompiledName">The random name .NET gave to my last in MEMORY compile
    /// objectReturned.GetType().Module.ScopeName.Replace(".dll", "") to get the name.</param>
    /// <param name="doForceCompile">If i want to override the one in MEMORY</param>
    /// <param name="errors"></param>
    /// <returns></returns>
    public IScriptBuilder CompileCodeDomCSharp(String scriptString, string lastCompiledName, bool doForceCompile, out List<string> errors)
    {
        var providerOptions = new Dictionary<string, string>();
        providerOptions.Add("CompilerVersion", "v4.0");
        var provider = new Microsoft.CSharp.CSharpCodeProvider(providerOptions);
        var cp = new CompilerParameters(new[] { "System.Core.dll" }) {
            GenerateExecutable = false,
            GenerateInMemory = true,
            TreatWarningsAsErrors = false,
            WarningLevel = 3,
            CompilerOptions = "/optimize",
            IncludeDebugInformation = false
        };
        cp.ReferencedAssemblies.Add(typeof(IScriptBuilder).Assembly.Location);
        // will write file to  C:\newprojects\NewPayroll\Utilities\CSharpScriptingTest\CSharpScriptWriter\CSharpScriptWriter\bin\Debug  -- causes issues for me.
        // cp.OutputAssembly = "MyScriptRunner";        
        errors = new List<string>();
        try
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type type;
            // use actual name if OutputAssembly is set
            // if (doForceCompile || x.All(a => a.FullName != "MyScriptRunner, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"))   
            if (doForceCompile || assemblies.All(a => a.FullName != lastCompiledName + ", Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"))
            {
                var results = provider.CompileAssemblyFromSource(cp, scriptString);
                type = results.CompiledAssembly.GetType("MyScriptRunner");
            }
            else
            {
                // use actual name if OutputAssembly is set
                // var myScriptRunner = x.FirstOrDefault(a => a.FullName == "MyScriptRunner, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");   
                var myScriptRunner = assemblies.FirstOrDefault(a => a.FullName == lastCompiledName + ", Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
                var myScriptRunnerObject = myScriptRunner.CreateObject("*");
                type = myScriptRunnerObject.GetType();
            }
            dynamic obj = Activator.CreateInstance(type);
            return (IScriptBuilder)obj;
        }
        catch (Exception ex)
        {
            // Not returning or handling error an my test app.
            return null;
        }
    }
