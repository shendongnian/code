    static class TestHelpers
    {
        public static void TestAll(this object o)
        {
            foreach (MethodInfo meth in o.GetType().GetMethods().
                Where((a) => a.GetCustomAttributes(true).
                    Any((b) => b.GetType().Name.Contains("TestMethod"))))
            {
                Console.WriteLine();
                Console.WriteLine("--- Testing {0} ---", meth.Name);
                Console.WriteLine();
                // Add exception handling here for your CI solution.
                var del = (Action)meth.CreateDelegate(typeof(Action), o);
                del();
                // NOTE: Don't use meth.Invoke(o, new object[0]); ! It'll eat your exception!
                Console.WriteLine();
            }
        }
        public static void TestAll(this Assembly ass)
        {
            HashSet<AssemblyName> visited = new HashSet<AssemblyName>();
            Stack<Assembly> todo = new Stack<Assembly>();
            todo.Push(ass);
            HandleStack(visited, todo);
        }
        private static void HandleStack(HashSet<AssemblyName> visited, Stack<Assembly> todo)
        {
            while (todo.Count > 0)
            {
                var assembly = todo.Pop();
                // Collect all assemblies that are related
                foreach (var refass in assembly.GetReferencedAssemblies())
                {
                    TryAdd(refass, visited, todo);
                }
                foreach (var type in assembly.GetTypes().
                    Where((a) => a.GetCustomAttributes(true).
                        Any((b) => b.GetType().Name.Contains("TestClass"))))
                {
                    // Add exception handling here for your CI solution.
                    var obj = Activator.CreateInstance(type);
                    obj.TestAll();
                }
            }
        }
        public static void TestAll()
        {
            HashSet<AssemblyName> visited = new HashSet<AssemblyName>();
            Stack<Assembly> todo = new Stack<Assembly>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                TryAdd(assembly.GetName(), visited, todo);
            }
            HandleStack(visited, todo);
        }
        private static void TryAdd(AssemblyName ass, HashSet<AssemblyName> visited, Stack<Assembly> todo)
        {
            try
            {
                var reference = Assembly.Load(ass);
                if (reference != null &&
                    !reference.GlobalAssemblyCache &&           // Ignore GAC
                    reference.FullName != null && 
                    !reference.FullName.StartsWith("ms") &&     // mscorlib and other microsoft stuff
                    !reference.FullName.StartsWith("vshost") && // visual studio host process
                    !reference.FullName.StartsWith("System"))   // System libraries
                {
                    if (visited.Add(reference.GetName()))       // We don't want to test assemblies twice
                    {
                        todo.Push(reference);                   // Queue assembly for processing
                    }
                }
            }
            catch
            {
                // Perhaps log something here... I currently don't because I don't care...
            }
        }
    }
