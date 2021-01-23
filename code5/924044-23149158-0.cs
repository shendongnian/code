            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            var cp = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            cp.ReferencedAssemblies.Add("mscorlib.dll");
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            // The string can contain any valid c# code
            // A valid class need to be created with its own properties.
            var s = "public class POCOClass{ public int ID {get {return 1;}} }";
            // "results" will usually contain very detailed error messages
            var results = csc.CompileAssemblyFromSource(cp, s);
            var type = results.CompiledAssembly.GetType("POCOClass");
            var obj = (dynamic)Activator.CreateInstance(type);
            var output = obj.ID;
            // or 
            var output_ = obj.GetType().GetProperty("ID").GetValue(obj, null);
