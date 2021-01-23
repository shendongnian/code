     EntityObject entity = null; //your entity
     MetadataWorkspace metadataWorkspace = dataContext.MetadataWorkspace;
     
     Type currentEntityType = entity.GetType();
     EntityType entityType = metadataWorkspace.GetItem<EntityType>(currentEntityType.FullName, DataSpace.OSpace);
     var simpleProperties = entityType.Properties.Where(p => p.DeclaringType == entityType && p.TypeUsage.EdmType is SimpleType);
    
     foreach (EdmProperty simpleProperty in simpleProperties)
         {
            Console.WriteLine(string.Format("Name: {0} Type: {1}", simpleProperty.Name,simpleProperty.TypeUsage));
         }
