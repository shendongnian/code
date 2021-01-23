    class AssemblyReferenceComparison : IComparer<Assembly>
    {
        public int Compare(Assembly x, Assembly y)
        {
            if (x == y) return 0;
            if (GetReferencesAssemblies(x).Contains(y)) return -1;
            if (GetReferencesAssemblies(y).Contains(x)) return 1;
            return 0;
        }
        private static IEnumerable<Assembly> GetReferencesAssemblies(Assembly a)
        {
            var referencedAssemblies = new HashSet<Assembly>();
            FillReferencesAssemblies(a, referencedAssemblies);
            return referencedAssemblies;
        }
        private static void FillReferencesAssemblies(Assembly a, HashSet<Assembly> referencedAssemblies)
        {
            referencedAssemblies.Add(a);
            var directAssemblies = a.GetReferencedAssemblies()
                .Select(name => Load(name))
                .Where(asm => asm != null)
                .Where(asm => !referencedAssemblies.Contains(asm))
                .ToArray();
            foreach (var directAssembly in directAssemblies)
            {
                FillReferencesAssemblies(directAssembly, referencedAssemblies);
            }
        }
        [DebuggerStepThrough]
        private static Assembly Load(AssemblyName name)
        {
            try { return Assembly.Load(name); }
            catch { return null; }
        }
    }
