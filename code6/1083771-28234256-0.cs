	public class DynamicFunction
    {
        private static int _counter = 0;
        private const string ClassBody = "{2} public static class DynamicFunctionHost{0} {{ {1} }}";
        private const string ClassName = "DynamicFunctionHost{0}";
        private const string FunctionName = "func";
        private const string T1FuncBody = "public static {1} func({0} param1){{ {2} }}";
        public static Func<T1, TResult> Get<T1, TResult>(string funcBody, string[] referenced, string[] usingNs)
        {
            var code = String.Format(ClassBody, _counter,
                String.Format(T1FuncBody, typeof (T1).Name, typeof (TResult).Name, funcBody),
                String.Join("\n", usingNs.Select(r => String.Format("using {0};", r))));
            var result = Compile(code, referenced);
            var host =
                result.CompiledAssembly.DefinedTypes.Single(
                    typeinfo => typeinfo.FullName.Equals(String.Format(ClassName, _counter)));
            ++_counter;
            return input => (TResult) host.GetMethod(FunctionName).Invoke(null, new object[] { input });
        }
        private static CompilerResults Compile(string code, string[] referenced)
        {
            var compiler = new CSharpCodeProvider();
            var parameters = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            foreach (var r in referenced)
                parameters.ReferencedAssemblies.Add(r);
            
            var results = compiler.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.Count == 0) return results;
            // else
            var e = new ArgumentException("Errors during compilation", "code");
            e.Data.Add("Errors", results.Errors);
            throw e;
        }
    }
