    class Program
    {
        static void Main(string[] args)
        {
            AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
            newDomain.AssemblyLoad += newDomain_AssemblyLoad;
            List<string> dllPaths = new List<string>() { @"c:\temp\taglib-sharp.dll" };
            AppDomainHelper.LoadToDomain(newDomain, dllPaths);
            newDomain.DoCallBack(new CrossAppDomainDelegate(AppDomainHelper.DoWorkWithAppDomain));
            AppDomain.Unload(newDomain);
            Console.ReadKey();
        }
                
        private static void newDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("{0} loaded into new domain", args.LoadedAssembly.FullName);
        }
        [Serializable]
        public class AppDomainHelper
        {
            private byte[] AsmData;
            public static void DoWorkWithAppDomain()
            {
                Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly asm in asms)
                {
                    Type[] types = asm.GetTypes();
                    foreach (Type type in types)
                    {
                        Console.WriteLine("Found the type: {0}", type.FullName);
                    }
                }
            }
            private void LoadAsm()
            {
                Assembly asm = Assembly.Load(AsmData);
            }
            public static void LoadToDomain(AppDomain domain,List<string> dlls)
            {
                foreach (string dll in dlls)
                {
                    AppDomainHelper asmLoad = new AppDomainHelper() { AsmData = File.ReadAllBytes(dll) };
                    domain.DoCallBack(new CrossAppDomainDelegate(asmLoad.LoadAsm));
                }
            }
        }
    }
