          public static IEnumerable<TableMapping> GetMappings(this DbContext context)
                {
                  
    
      List<TableMapping> tableMappings = new List<TableMapping>();
    
                var storageMapping = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace.GetItem<GlobalItem>(((IObjectContextAdapter)context).ObjectContext.DefaultContainerName, DataSpace.CSSpace);
    
                dynamic entitySetMaps = storageMapping.GetType().InvokeMember(
                    "EntitySetMaps",
                    BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance,
                    null, storageMapping, null);
    
                foreach (var entitySetMap in entitySetMaps)
                {
                    var typeMappings = GetArrayList("EntityTypeMappings", entitySetMap);
                    dynamic typeMapping = typeMappings[0];
                    dynamic types = GetArrayList("Types", typeMapping);
    
                    var fragments = GetArrayList("MappingFragments", typeMapping);
                    var fragment = fragments[0];
    
                    var tableSet = GetProperty("TableSet", fragment);
                    var tableName = GetProperty("Name", tableSet);
    
                    TableMapping tm = new TableMapping
                    {
                        Entity = context.FindContextTableName((string)types[0].Name),
                        Table = tableName
                    };
    
                    var properties = GetArrayList("AllProperties", fragment);
    
                    List<ColumnMapping> columnMappings = new List<ColumnMapping>();
                    foreach (var property in properties)
                    {
                        var edmProperty = GetProperty("EdmProperty", property);
                        var columnProperty = GetProperty("ColumnProperty", property);
                    
                        ColumnMapping cm = new ColumnMapping
                        {
                            Property = edmProperty.Name,
                            Column = columnProperty.Name
                        };
                        columnMappings.Add(cm);
                    }
    
                    tm.Columns = columnMappings.AsEnumerable();
                    tableMappings.Add(tm);
                }
    
                return tableMappings.AsEnumerable();
            }
    
            private static ArrayList GetArrayList(string property, object instance)
            {
                var type = instance.GetType();
                var objects = (IEnumerable)type.InvokeMember(
                    property,
                    BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance, null, instance, null);
                var list = new ArrayList();
                foreach (var o in objects)
                {
                    list.Add(o);
                }
                return list;
            }
    
            private static dynamic GetProperty(string property, object instance)
            {
                var type = instance.GetType();
                return type.InvokeMember(property, BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance, null, instance, null);
            }
