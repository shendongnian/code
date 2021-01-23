    public void EFTools2Test()
        {
            var context = new MyContext("MYConnie");
            ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;
            MetadataWorkspace workspace = objContext.MetadataWorkspace;
            IEnumerable<EntityType> managedTypes = workspace.GetItems<EntityType>(DataSpace.OSpace);
            var result = new List<Type>();
            foreach (var managedType in managedTypes) {
          
                Console.WriteLine(managedType.FullName);
                foreach ( var p in managedType.Properties) {
                    Console.WriteLine(p.Name );
                }
            }
            
        }
  
    
        public void EFToolsTest() {
        //  http://msdn.microsoft.com/en-us/library/system.data.metadata.edm.dataspace(v=vs.110).aspx
            var context = new MyContext("MYConnie");
            ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;
            MetadataWorkspace workspace = objContext.MetadataWorkspace;
 
            var xyz = workspace.GetItems<EntityType>(DataSpace.SSpace);
            foreach (var ET in xyz) {
                foreach (var sp in ET.Properties) {
                    Debug.WriteLine(sp.Name + ":" + sp.MaxLength);// just as an example
                    
                    }
                }
            }
