    static Type GetType( string friendlyName )
    {
    	var csc = new CSharpCodeProvider();
    	var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "temp.dll", false);
    	parameters.GenerateExecutable = false;
    	parameters.GenerateInMemory = true;
    	CompilerResults results = csc.CompileAssemblyFromSource(parameters,
    		@"public static class TypeInfo {
    			public static System.Type GetEmbeddedType() {
    			return typeof(" + friendlyName + @");
    			}
    		}");
    	if (results.Errors.Count > 0)
    		throw new Exception( "Error compiling type name." );
    	Type[] type = results.CompiledAssembly.GetExportedTypes();
    	return type[0];
    }
