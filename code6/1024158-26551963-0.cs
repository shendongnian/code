        public static  IList<Type> GetContextManagedTypes(DbContext context) {
            ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;
            MetadataWorkspace workspace = objContext.MetadataWorkspace;
            IEnumerable<EntityType> managedTypes = workspace.GetItems<EntityType>(DataSpace.OSpace);
            var typeList = new List<Type>();
            foreach (var managedType in managedTypes) {
                var pocoType = managedType.FullName.GetCoreType();
                typeList.Add(pocoType);
            }
            return typeList;
        }
