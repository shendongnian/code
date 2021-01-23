    public class AssemblyItem {
        public Assembly Item { get; set; }
        public IList<AssemblyItem> Dependencies { get; set; }
    
        public AssemblyItem(Assembly item) {
            Item = item;
            Dependencies = new List<AssemblyItem>();
        }
    }
    
    public static void Main() {
        // Get the assemblies
        var assemblyItems = BuildManager.GetReferencedAssemblies().Cast<Assembly>().OrderBy(a => a.FullName).Select(a => new AssemblyItem(a)).ToList();
    
        // Add the dependencies
        foreach (var item in assemblyItems) {
            foreach (var reference in item.Item.GetReferencedAssemblies()) {
                var dependency = assemblyItems.SingleOrDefault(i => i.Item.FullName == reference.FullName);
    
                if (dependency != null)
                    item.Dependencies.Add(dependency);
            }
        }
    
        // Sort the assemblies
        var sortedAssemblyItems = assemblyItems.TSort(i => i.Dependencies);
    }
