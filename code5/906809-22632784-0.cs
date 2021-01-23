        private readonly Object lockCompile = new Object();
        public CompilerResults Compile(String code)
        {
            CompilerResults result = null;
            lock (lockCompile)
            {
                using (CSharpCodeProvider codeProvider = new CSharpCodeProvider())
                {
                    result = codeProvider
                       .CompileAssemblyFromSource(this.compilerParameters, code);
                }
            }
            return result;
        }
