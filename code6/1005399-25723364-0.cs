        private KeyValuePair<String, Int64> GenerateCodeInt64(String mathKey)
        {
            string codeNamespace = "MathTestCalculator";
            string codeClassName = "MathTestCalculator";
            string codeMethodName = "Value";
            Int64 I64Value = 0;
            StringBuilder codeBuilder = new StringBuilder();
            codeBuilder
                .Append("using System;\n")
                .Append("namespace ").Append(codeNamespace).Append(" {\n")
                .Append("class ").Append(codeClassName).Append("{\n")
                .Append("public Int64 ").Append(codeMethodName).Append("(){\n")
                .Append("return (Int64)(").Append(mathKey).Append(");}}}\n");
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;
            CompilerResults results = CodeDomProvider
                .CreateProvider("CSharp")
                .CompileAssemblyFromSource(cp, codeBuilder.ToString());
            if (results.Errors.Count > 0)
            {
                StringBuilder error = new StringBuilder();
                error.Append("Unable to evaluate: '").Append(mathKey).Append("'\n");
                foreach (CompilerError CompErr in results.Errors)
                {
                    error
                        .Append("Line number ").Append(CompErr.Line)
                        .Append(", Error Number: ").Append(CompErr.ErrorNumber)
                        .Append(", '").Append(CompErr.ErrorText).Append(";\n");
                }
                throw new Exception(error.ToString());
            }
            else
            {
                Type calcType = results.CompiledAssembly.GetType(codeNamespace + "." + codeClassName);
                object o = Activator.CreateInstance(calcType);
                I64Value = (Int64)calcType.GetMethod(codeMethodName).Invoke(o, null);
            }
            return new KeyValuePair<string, long>(mathKey, I64Value);
        }
