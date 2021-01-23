        public Type ConvertIEdmEntityTypeToClr(IEdmEntityType edmEntityType, DbContext context)
        {
            var metadata = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
            var oSpace = metadata.GetItemCollection(DataSpace.OSpace);
            var typeName = oSpace.GetItems<EntityType>().Select(e => e.FullName).FirstOrDefault(name =>
                {
                    var fullname = name + ":" + edmEntityType.FullName();
                    MappingBase map;
                    return metadata.TryGetItem(fullname, DataSpace.OCSpace, out map);
                });
            return Type.GetType(typeName, false);
        }
