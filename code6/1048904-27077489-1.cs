    class Program
    {
        static void Main(string[] args)
        {
            AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
            List<string> dllPaths = new List<string>() { @"c:\dev\taglib-sharp.dll" };
            foreach (string dll in dllPaths)
            {
                AppDomainAsmLoader asmLoad = new AppDomainAsmLoader(File.ReadAllBytes(dll));
                newDomain.DoCallBack(new CrossAppDomainDelegate(asmLoad.LoadAsm));
            }
            newDomain.DoCallBack(new CrossAppDomainDelegate(DoWorkWithAppDomain));
            AppDomain.Unload(newDomain);
            Console.ReadKey();
        }
        
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
        [Serializable]
        public class AppDomainAsmLoader
        {
            private byte[] AsmData;  
            public AppDomainAsmLoader(byte[] data)
            {
                AsmData = data;
            }         
            public void LoadAsm()
            {
                Assembly asm = Assembly.Load(AsmData);
            }
        }
    }
