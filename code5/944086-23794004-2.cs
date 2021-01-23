    class Program
    {
        static void Main( string[] args )
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var referencedAssemblies = currentAssembly.GetReferencedAssemblies();
            var typesFromReferencedAssemblies = referencedAssemblies.Select( assemblyName => Assembly.ReflectionOnlyLoad( assemblyName.FullName ) ).SelectMany( assembly => assembly.GetTypes() );
        }
    }
