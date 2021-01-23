    public class AssemblyInfo
    {
        public readonly Assembly Item;
        public readonly IList<AssemblyInfo> ReferencedAssemblies;
        public AssemblyInfo(Assembly item)
        {
            Item = item ?? throw new NullReferenceException("Item is null");
            ReferencedAssemblies = new List<AssemblyInfo>();
        }
        int Count()
        {
            return ReferencedAssemblies.Count;
        }
        public override string ToString()
        {
            return Item.FullName;
        }
        public IEnumerable<AssemblyInfo> OrderedDependencies()
        {
            List<AssemblyInfo> localOrdered = new List<AssemblyInfo>();
            foreach (AssemblyInfo item in ReferencedAssemblies.OrderBy(t => t.Count()))
            {
                IEnumerable<AssemblyInfo> temp = item.OrderedDependencies();
                localOrdered = localOrdered.Union<AssemblyInfo>(temp).ToList();
            }
            localOrdered.Add(this);
            return localOrdered;
        }
        public override bool Equals(object obj)
        {
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(obj, null))
            {
                return false;
            }
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }
            return Item.FullName.Equals(((AssemblyInfo)obj).Item.FullName);
        }
        public override int GetHashCode()
        {
            //Get hash code for the Name field if it is not null.
            return Item.FullName.GetHashCode();
        }
        public static AssemblyInfo Parse(string assembliesPath, string assemblyName)
        {
            return Parse(assembliesPath, assemblyName, new Dictionary<string, Assembly>());
        }
        static AssemblyInfo Parse(string assembliesPath, string assemblyName, Dictionary<string, Assembly> loadedAssemblies)
        {
            string assemblyFullPath = Path.Combine(assembliesPath, assemblyName);
            if (!File.Exists(assemblyFullPath))
            {
                return null;
            }
            if (loadedAssemblies == null)
            {
                loadedAssemblies = new Dictionary<string, Assembly>();
            }
            if (!loadedAssemblies.ContainsKey(assemblyFullPath))
            {
                loadedAssemblies.Add(assemblyFullPath, Assembly.Load(File.ReadAllBytes(assemblyFullPath)));
            }
            Assembly a = loadedAssemblies[assemblyFullPath];
            AssemblyInfo ai = new AssemblyInfo(a);
            foreach (AssemblyName an in a.GetReferencedAssemblies())
            {
                AssemblyInfo d = Parse(assembliesPath, an.Name + ".dll", loadedAssemblies);
                if (d != null)
                {
                    ai.ReferencedAssemblies.Add(d);
                }
            }
            return ai;
        }
    }
