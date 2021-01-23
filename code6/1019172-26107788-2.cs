    class Program
    {
        static void Main(string[] args)
        {
            var assemblyBytes = File.ReadAllBytes(@"C:\dev\Newtonsoft.Json.dll");
            // load an unload the same assembly 5 times
            for (int i = 0; i < 5; i++)
            {
                var assemblyContainer = AssemblyContainer.LoadAssembly(assemblyBytes, true);
                var assemblyName = assemblyContainer.AssemblyName;
                assemblyContainer.Unload();
            }
            
            Console.ReadKey();
        }
    }    
    [Serializable]
    public class AssemblyContainer
    {
        public byte[] AssemblyData { get; set; }
        public bool ReflectionOnly { get; set; }
        private AppDomain Container { get; set; }
        public AssemblyName AssemblyName { get; set; }
            
        /// <summary>
        /// Unload the domain containing the assembly
        /// </summary>
        public void Unload()
        {
            AppDomain.Unload(Container);
        }
        /// <summary>
        /// Load the assembly
        /// </summary>
        /// <remarks>This will be executed</remarks>
        public void LoadAssembly()
        {                
            var assembly = ReflectionOnly ? Assembly.ReflectionOnlyLoad(AssemblyData) : Assembly.Load(AssemblyData);
            AssemblyName = assembly.GetName();
            // set data to pick up from the main app domain
            Container.SetData("AssemblyData", AssemblyName);
        }
        /// <summary>
        /// Load the assembly into another domain
        /// </summary>
        /// <param name="assemblyBytes"></param>
        /// <param name="reflectionOnly"></param>
        /// <returns></returns>
        public static AssemblyContainer LoadAssembly(byte[] assemblyBytes, bool reflectionOnly = false)
        {
            var containerAppDomain = AppDomain.CreateDomain(
                "AssemblyContainer",
                AppDomain.CurrentDomain.Evidence,
                new AppDomainSetup
                {
                    ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
                },
                new PermissionSet(PermissionState.Unrestricted));
            AssemblyContainer assemblyContainer = new AssemblyContainer()
            {
                AssemblyData = assemblyBytes,
                ReflectionOnly = reflectionOnly,
                Container = containerAppDomain
            };
                
            containerAppDomain.DoCallBack(new CrossAppDomainDelegate(assemblyContainer.LoadAssembly));
            // collect data from the other app domain
            assemblyContainer.AssemblyName = (AssemblyName)containerAppDomain.GetData("AssemblyData");
            return assemblyContainer;
        }            
    }    
