    [LoaderOptimization(LoaderOptimization.MultiDomain)]
        static void Main(String[] args)
        {
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            var dir = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\EF\bin\Debug");
            var evidence = new Evidence();
            var setup = new AppDomainSetup { ApplicationBase = dir };
            var domain = AppDomain.CreateDomain("Plugin", evidence, setup);
            domain.AssemblyLoad += domain_AssemblyLoad;
            var pluginDll = Path.Combine(dir, "EF.Plugin.dll");
            var anotherDomainPlugin = (IPlugin)domain.CreateInstanceFromAndUnwrap(pluginDll, "EF.Plugin.SamplePlugin");
            var mainDomainPlugin = new SamplePlugin();
            mainDomainPlugin.Do();    // To prevent side effects of entity framework startup from our test
            anotherDomainPlugin.Do(); // To prevent side effects of entity framework startup from our test
            Stopwatch watch = Stopwatch.StartNew();
            mainDomainPlugin.Do();
            watch.Stop();
            Console.WriteLine("Main Application Domain -------------------------- " + watch.ElapsedMilliseconds.ToString());
            watch.Restart();
            anotherDomainPlugin.Do();
            watch.Stop();
            Console.WriteLine("Another Application Domain -------------------------- " + watch.ElapsedMilliseconds.ToString());
            Console.ReadLine();
        }
        static void CurrentDomain_AssemblyLoad(Object sender, AssemblyLoadEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Main Domain : " + args.LoadedAssembly.FullName);
        }
        static void domain_AssemblyLoad(Object sender, AssemblyLoadEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Another Domain : " + args.LoadedAssembly.FullName);
        }
