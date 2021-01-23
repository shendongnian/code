    public MyCustomObject BindAssembly()
    {
        string currentAssemblyPath = @"C:\PathToMy\Assembly";
        string currentAssemblyFile = @"C:\PathToMy\Assembly\MyAssembly.dll";
        AssemblyName currentAssemblyName = AssemblyName.GetAssemblyName(currentAssemblyFile);
        AppDomain domain = AppDomain.CurrentDomain;
        domain.AssemblyResolve += domain_AssemblyResolve;
        AppDomainSetup setup = new AppDomainSetup()
        {
            PrivateBinPath = currentAssemblyPath,
            ApplicationBase = domain.BaseDirectory,
            DynamicBase = domain.SetupInformation.DynamicBase,
            ShadowCopyFiles = domain.SetupInformation.ShadowCopyFiles,
            CachePath = domain.SetupInformation.CachePath,
            AppDomainManagerAssembly = domain.SetupInformation.AppDomainManagerAssembly,
            AppDomainManagerType = domain.SetupInformation.AppDomainManagerType
        };
        AppDomain newDomain = AppDomain.CreateDomain("NewDomain", AppDomain.CurrentDomain.Evidence, setup);
        newDomain.Load(typeof(Loader).Assembly.GetName());
        Loader loader = (Loader)newDomain.CreateInstanceAndUnwrap(
            typeof(Loader).Assembly.FullName, typeof(Loader).FullName);
        // load the assembly containing MyCustomObject into the remote domain
        loader.LoadAssembly(currentAssemblyFile);
        // ask the Loader to create the object instance for us
        MyCustomObject obj = loader.CreateCustomObject();
        return obj;
    }
    public class Loader : MarshalByRefObject
    {
        /// <summary>Stores the assembly containing the task class.</summary>
        private Assembly assembly;
        /// <summary>Retrieves the current lifetime service object that controls the lifetime policy for this instance.</summary>
        /// <returns>This always returns null.</returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
        /// <summary>Loads the assembly containing the task class.</summary>
        /// <param name="path">The full path to the assembly DLL containing the task class.</param>
        public void LoadAssembly(string path)
        {
            this.assembly = Assembly.Load(AssemblyName.GetAssemblyName(path));
        }
        /// <summary>Instantiates the required object.</summary>
        /// <param name="classFullName">The full name (namespace + class name) of the task class.</param>
        /// <returns>The new object.</returns>
        public MyCustomObject CreateCustomObject()
        {
            MyCustomObject instance = new MyCustomObject();
            // do whatever you want with the instance here
            return instance;
        }
    }
