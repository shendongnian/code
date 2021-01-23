       public static  void DumpContextManagedTypeProps() {
           var context = new YourContent();
            ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;
            MetadataWorkspace workspace = objContext.MetadataWorkspace;
            IEnumerable<EntityType> managedTypes = workspace.GetItems<EntityType>(DataSpace.OSpace);
            foreach (var managedType in managedTypes.Where(mt=>mt.Ful) {
            Console.WriteLine(managedType.FullName);
            // propertyInfo and other useful info is available....
            foreach ( var p in managedType.Properties) {
                    Console.WriteLine(p.Name );
                }
            }
            return result;
        }
