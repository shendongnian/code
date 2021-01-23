    CompilerParameters parms = new CompilerParameters
                                               {
                                                   GenerateExecutable = false,
                                                   GenerateInMemory = true,
                                                   IncludeDebugInformation = false
                                               };
    
                parms.ReferencedAssemblies.Add("System.dll");
                parms.ReferencedAssemblies.Add("System.Data.dll");
                CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp"); 
    
                return compiler.CompileAssemblyFromSource(parms, source); 
