    [Obfuscation(Exclude = true, ApplyToMembers = true)]
    public interface IXyFunction<TInput, TOutput>
    {
        TOutput Run(TInput x, TInput y);
    }
    public static class CodeProvider
    {
        public static string LastError { get; private set; }
        private static int counter;
        public static IXyFunction<TInput, TOutput> Generate<TInput, TOutput>(string code)
        {
            return Generate<TInput, TOutput>(code, null);
        }
        public static IXyFunction<TInput, TOutput> Generate<TInput, TOutput>(string code, string[] assemblies)
        {
            if (String.IsNullOrEmpty(code))
                throw new ArgumentNullException("code");
            const string ERROR = "Error(s) while compiling";
            string className = "_generated_" + counter++;
            string typeInName = typeof(TInput).FullName;
            string typeOutName = typeof(TOutput).FullName;
            string namespaceName = typeof(CodeProvider).Namespace;
            string fullClassName = namespaceName + "." + className;
            LastError = String.Empty;
            CSharpCodeProvider codeCompiler = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v3.5" } });
            CompilerParameters parameters = new CompilerParameters(assemblies)
                                                {
                                                    GenerateExecutable = false,
                                                    GenerateInMemory = true,
                                                    CompilerOptions = "/optimize"
                                                };
            string path = Assembly.GetExecutingAssembly().Location;
            parameters.ReferencedAssemblies.Add(path);
            if (typeof(CodeProvider).Assembly.Location != path)
                parameters.ReferencedAssemblies.Add(typeof(CodeProvider).Assembly.Location);
            string executerName = typeof(IXyFunction<TInput, TOutput>).FullName;
            executerName = executerName.Substring(0, executerName.IndexOf('`'));
            code = @"               using System;
                namespace " + namespaceName + @"
                {     
                    public class " + className + @" : " + executerName + "<" + typeInName + ", " + typeOutName + @">
                    {
                        public " + typeOutName + @" Run(" + typeInName + @" x, " + typeInName + @" y)
                        {"
                   + code + @"
                        }
                    }
                }";
            CompilerResults results = codeCompiler.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                System.Text.StringBuilder err = new System.Text.StringBuilder(512);
                foreach (CompilerError error in results.Errors)
                    err.Append(string.Format("Line: {0:d}, Error: {1}\r\n", error.Line, error.ErrorText));
                Console.WriteLine(err);
                LastError = err.ToString();
                return null;
            }
            object objMacro = results.CompiledAssembly.CreateInstance(fullClassName);
            if (objMacro == null)
                throw new ApplicationException(ERROR + " class " + className);
            return (IXyFunction<TInput, TOutput>)objMacro;
        }
    }
