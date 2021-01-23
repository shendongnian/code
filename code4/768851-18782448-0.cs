    class Program
    {
        static void Main(string[] args)
        {
            // This is for testing purposes!
            var loadedAssembliesBefore = AppDomain.CurrentDomain.GetAssemblies();
            var domain = AppDomain.CreateDomain("ChildDomain");                        
            // This will make the call to the static method in the dhild AppDomain.
            domain.DoCallBack(LoadAssemblyAndCallStaticMethod);
            // Print the loaded assemblies on the child AppDomain. This is for testing purposes!
            domain.DoCallBack(PrintLoadedAssemblies);
            AppDomain.Unload(domain);
            // This is for testing purposes!
            var loadedAssembliesAfter = AppDomain.CurrentDomain.GetAssemblies();
            // Assert that no assembly was leaked to the main AppDomain.
            Debug.Assert(!loadedAssembliesBefore.Except(loadedAssembliesAfter).Any());
            Console.ReadKey();
        }
        // Loads StaticMethodInHere.dll to the current AppDomain and calls static method 
        // StaticClass.DoSomething.  
        static void LoadAssemblyAndCallStaticMethod()
        {
            var assembly = Assembly.LoadFrom(@"PATH_TO_ASSEMBLY");
            assembly.GetType("CLASS_CONTAINING_STATIC_METHOD")
                    .InvokeMember("STATIC_METHOD", 
                                  BindingFlags.Public | 
                                  BindingFlags.Static | 
                                  BindingFlags.InvokeMethod, 
                                  null, 
                                  null, 
                                  null);
        }
        // Prints the loaded assebmlies in the current AppDomain. For testing purposes.
        static void PrintLoadedAssemblies()
        {
            Console.WriteLine("/ Assemblies in {0} -------------------------------",
                              AppDomain.CurrentDomain.FriendlyName);
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine(assembly.FullName);
            }            
        }
    }
