    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    namespace DynamicCalcTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var result = new DynamicCalculator<double>("2 + 2 * 2").Execute();
            }
        }
        public class DynamicCalculator<T>
        {
            private MethodInfo _Method = null;
            public DynamicCalculator(string code)
            {
                _Method = GetMethodInfo(code);
            }
            public T Execute()
            {
                return (T)_Method.Invoke(null, null);
            }
            private MethodInfo GetMethodInfo(string code)
            {
                var tpl = @"
                    public static class Calculator
                    {{
                        public static double Calc()
                        {{
                            return {0};
                        }}
                    }}";
                var finalCode = string.Format(tpl, code);
                var parameters = new CompilerParameters();
                parameters.ReferencedAssemblies.Add("mscorlib.dll");
                parameters.GenerateInMemory = true;
                parameters.CompilerOptions = "/platform:anycpu";
                var options = new Dictionary<string, string> { { "CompilerVersion", "v4.0" }     };
                var c = new CSharpCodeProvider(options);
                var results = c.CompileAssemblyFromSource(parameters, finalCode);
                var type = results.CompiledAssembly.GetExportedTypes()[0];
                var mi = type.GetMethod("Calc");
                return mi;
            }
        }
    }
