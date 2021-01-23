            // create compiler
            CodeDomProvider provider = CSharpCodeProvider.CreateProvider("C#");
            CompilerParameters options = new CompilerParameters();
            // add more references if needed
            options.ReferencedAssemblies.Add("system.dll");
            options.GenerateExecutable = false;
            options.GenerateInMemory = true;
            // compile the code
            string source = ""; // put here source
            CompilerResults result = provider.CompileAssemblyFromSource(options, source);
            if (!result.Errors.HasErrors)
            {
                Assembly assembly = result.CompiledAssembly;
                // instance can be saved and then reused whenever you need to run the code
                var instance = assembly.CreateInstance("Bla.Blabla");
                // running some method
                MethodInfo method = instance.GetType().GetMethod("Test"));
                var result = (bool)method.Invoke(null, new object[] {});
                // untested, but may works too
                // dynamic instance = assembly.CreateInstance("Bla.Blabla");
                // var result = instance.Test();
            }
