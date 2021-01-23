    public static class TypeExtensions
    {
        public static IEnumerable<Type> DerivedTypes(this IEnumerable<Type> baseTypes)
        {
            var assemblies = baseTypes.SelectMany(t => t.Assembly.GetReferencingAssembliesAndSelf()).Distinct();
            return assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => baseTypes.Any(baseType => baseType.IsAssignableFrom(t)))
                .Distinct();
        }
    }
    public static class AssemblyExtensions
    {
        public static IEnumerable<Assembly> GetAllAssemblies()
        {
            // Adapted from 
            // https://stackoverflow.com/questions/851248/c-sharp-reflection-get-all-active-assemblies-in-a-solution
            return Assembly.GetEntryAssembly().GetAllReferencedAssemblies();
        }
        public static IEnumerable<Assembly> GetAllReferencedAssemblies(this Assembly root)
        {
            // WARNING: Assembly.GetAllReferencedAssemblies() will optimize away any reference if there
            // is not an explicit use of a type in that assembly from the referring assembly --
            // And simply adding an attribute like [XmlInclude(typeof(T))] seems not to do
            // the trick.  See
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/17f89058-5780-48c5-a43a-dbb4edab43ed/getreferencedassemblies-not-returning-complete-list?forum=netfxbcl
            // Thus if you are using this to, say, discover all derived types of a base type, the assembly
            // of the derived types MUST contain at least one type that is referenced explicitly from the 
            // root assembly, directly or indirectly.
            var list = new HashSet<string>();
            var stack = new Stack<Assembly>();
            stack.Push(root);
            do
            {
                var asm = stack.Pop();
                yield return asm;
                foreach (var reference in asm.GetReferencedAssemblies())
                    if (!list.Contains(reference.FullName))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }
            }
            while (stack.Count > 0);
        }
        public static IEnumerable<Assembly> GetReferencingAssemblies(this Assembly target)
        {
            if (target == null)
                throw new ArgumentNullException();
            // Assemblies can have circular references:
            // http://stackoverflow.com/questions/1316518/how-did-microsoft-create-assemblies-that-have-circular-references
            // So a naive algorithm isn't going to work.
            var done = new HashSet<Assembly>();
            var root = Assembly.GetEntryAssembly();
            var allAssemblies = root.GetAllReferencedAssemblies().ToList();
            foreach (var assembly in GetAllAssemblies())
            {
                if (target == assembly)
                    continue;
                if (done.Contains(assembly))
                    continue;
                var refersTo = (assembly == root ? allAssemblies : assembly.GetAllReferencedAssemblies()).Contains(target);
                done.Add(assembly);
                if (refersTo)
                    yield return assembly;
            }
        }
        public static IEnumerable<Assembly> GetReferencingAssembliesAndSelf(this Assembly target)
        {
            return new[] { target }.Concat(target.GetReferencingAssemblies());
        }
    }
