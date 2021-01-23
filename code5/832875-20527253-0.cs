    using System;
    using System.Reflection;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    
    namespace SimpleCompileTest
    {
        class Program
        {
            public static void Main(string[] args)
            {
                string typeName = "System.Collections.Generic.List<int>";
                Type theType = GetTypeFromName(typeName);
            }
    
            private static Type GetTypeFromName(string typeName)
            {
                // double open and close are for escape purposes
                const string typeProgram = @"using System; using System.Collections.Generic; using System.IO;
                    namespace SimpleTest
                    {{
                        public class Program
                        {{
                            public static Type GetItemType()
                            {{
                                {0} typeTest = new {0}();
                                if (typeTest == null) return null;
                                return typeTest.GetType();
                            }}
                        }}
                    }}";
    
                var formattedCode = String.Format(typeProgram, typeName);
    
                var CompilerParams = new CompilerParameters
                    {
                        GenerateInMemory = true,
                        TreatWarningsAsErrors = false,
                        GenerateExecutable = false,
                        CompilerOptions = "/optimize"
                    };
    
                string[] references = { "System.dll" };
                CompilerParams.ReferencedAssemblies.AddRange(references);
    
                var provider = new CSharpCodeProvider();
                CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, formattedCode);
                if (compile.Errors.HasErrors) return null;
    
    
                Module module = compile.CompiledAssembly.GetModules()[0];
                Type mt = null; MethodInfo methInfo = null;
    
                if (module != null) mt = module.GetType("SimpleTest.Program");
                if (mt != null) methInfo = mt.GetMethod("GetItemType");
                if (methInfo != null) return (Type)methInfo.Invoke(null, null);
    
                return null;
            }
        }
    }
