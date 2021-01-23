    public class AddInLoader
    {
        // Loads all non abstract types implementing IAddIn in all DLLs found in a folder.
        public IList<IAddIn> Load(string folder)
        {
            var addIns = new List<IAddIn>();
            string[] files = Directory.GetFiles(folder, "*.dll");
            foreach (string file in files) {
                addIns.AddRange(LoadFromAssembly(file));
            }
            return addIns;
        }
        // Loads all non abstract types implementing IAddIn found in a file.
        private static IEnumerable<IAddIn> LoadFromAssembly(string fileName)
        {
            Assembly asm = Assembly.LoadFrom(fileName);
            string addInInterfaceName = typeof(IAddIn).FullName;
            foreach (Type type in asm.GetExportedTypes()) {
                Type interfaceType = type.GetInterface(addInInterfaceName);
                if (interfaceType != null &&
                   (type.Attributes & TypeAttributes.Abstract) != TypeAttributes.Abstract){
                    IAddIn addIn = (IAddIn)Activator.CreateInstance(type);
                    addIn.Version = asm.GetName().Version.ToString();
                    yield return addIn;
                }
            }
        }
    }
