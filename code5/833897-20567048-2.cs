    private static class StrongClassComparer<T>
    {
        public static Func<T, string> GenerateMethod()
        {
            var code = new StringBuilder();
            // generate your STRONGLY-TYPED code here.
            // into code variable.
            code.Append("public class YourClassInCode { public static void YourClassStaticMethod() {} }");
            var compiler = new CSharpCodeProvider();
            var parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add(typeof (T).Assembly.Location);
            parameters.CompilerOptions = "/optimize + ";
            var results = compiler.CompileAssemblyFromSource(parameters, code.ToString());
            var @class = results.CompiledAssembly.GetType("YourClassInCode");
            var method = @class.GetMethod("YourClassStaticMethod");
            return (Func<T, string>) Delegate.CreateDelegate(typeof (Func<T, string>), method);
        }
    }
