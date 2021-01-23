    static Type GetType( string friendlyName )
    {
    	return (Type)(new CSharpCodeProvider().CompileAssemblyFromSource( new CompilerParameters( AppDomain.CurrentDomain.GetAssemblies().SelectMany<Assembly,string>( a => a.GetModules().Select<Module,string>( m => m.FullyQualifiedName )).ToArray(), null, false) {GenerateExecutable = false, GenerateInMemory = true, TreatWarningsAsErrors = false,	CompilerOptions = "/optimize"}, "public static class C{public static System.Type M(){return typeof(" + friendlyName + ");}}").CompiledAssembly.GetExportedTypes()[0].GetMethod("M").Invoke( null, System.Reflection.BindingFlags.Static, null, null, null ));
    }
    
    static string GetFriendlyName( Type type )
    {
        return new CSharpCodeProvider().GetTypeOutput(new CodeTypeReference(type));
    }
