    var columns = from meta in ctx.MetadataWorkspace.GetItems(DataSpace.CSpace)
                                           .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                           from p in (meta as EntityType).Properties
                           .Where(p => p.DeclaringType.Name == tableName)
                           select new
                           {
                               colName = p.Name,
                               colType = p.TypeUsage.EdmType.Name
                           };
