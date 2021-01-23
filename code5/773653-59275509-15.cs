    public class AssemblyResolver
    {
        readonly string assemblyFullPath;
        readonly AssemblyName assemblyName;
        public AssemblyResolver(string assemblyName, string assemblyFullPath)
        {
            // You might want to validate here that assemblyPath really is an absolute not relative path.
            // See e.g. https://stackoverflow.com/questions/5565029/check-if-full-path-given
            this.assemblyFullPath = assemblyFullPath;
            this.assemblyName = new AssemblyName(assemblyName);
        }
        public ResolveEventHandler AssemblyResolve
        {
            get
            {
                return (o, a) =>
                    {
                        var name = new AssemblyName(a.Name);
                        if (name.Name == assemblyName.Name) // Check only the name if you want to ignore version.  Otherwise you can just check string equality.
                            return Assembly.LoadFrom(assemblyFullPath);
                        return null;
                    };
            }
        }
    }
