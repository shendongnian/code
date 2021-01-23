    public class TestClass
    {
        //This dictionary will hold a list of the full path for an assembly, indexed by the assembly's full name
        private Dictionary<string, string> _allAsms = new Dictionary<string, string>();
        /// <summary>
        /// Tries to list all of the Types inside an assembly and any interfaces those types inherit from.
        /// </summary>
        /// <param name="pathName">The path of the original assembly, without the assembly file</param>
        /// <param name="fileName">The name of the assembly file as it is found on disk.</param>
        public void Search(string pathName, string fileName)
        {
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(CurrentDomain_ReflectionOnlyAssemblyResolve);
            
            //Getting a list of all possible assembly files that exist in the same location as the original assembly
            string[] filePaths = Directory.GetFiles(pathName, "*.dll", SearchOption.AllDirectories);
            Assembly asm;
            AssemblyName name;
            if (!pathName.EndsWith("\\"))
                pathName += "\\";
            foreach (string path in filePaths)
            {
                name = AssemblyName.GetAssemblyName(path);
                if (!_allAsms.ContainsKey(name.FullName))
                    _allAsms.Add(name.FullName, path);
            }
            //This is where we are loading the originaly assembly
            asm = System.Reflection.Assembly.ReflectionOnlyLoad(File.ReadAllBytes(pathName + fileName));
            Console.WriteLine("Opened assembly:{0}", fileName);
            //And this is where the ReflectionOnlyAssemblyResolve will start to be raised
            foreach (Type t in asm.GetTypes())
            {
                Console.WriteLine("  " + t.FullName);
                //Get the interfaces for the type;
                foreach (Type dep in t.GetInterfaces())
                {
                    Console.WriteLine("    " + dep.FullName);
                }
            }
        }
        private Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (_allAsms.ContainsKey(args.Name))
                return Assembly.ReflectionOnlyLoad(File.ReadAllBytes(_allAsms[args.Name]));
            else
                return System.Reflection.Assembly.ReflectionOnlyLoad(args.Name);
        }
    }
 
