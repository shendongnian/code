    using (WdmEntities context = new WdmEntities())
    {
        //get object models from context
        ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;
        //get all full names types from object model
        var fullNameTypes = objContext.MetadataWorkspace.GetItems<EntityType>(DataSpace.OSpace);
        ///////////////////
        var conStr = objContext.Connection.ConnectionString;
        var connection = new EntityConnection(conStr);
        var workspace = connection.GetMetadataWorkspace();
    
        var entitySets = workspace.GetItems<EntityContainer>(DataSpace.SSpace).First().BaseEntitySets;
                    
        for (int i = 0; i < fullNameTypes.Count; i++)
        {
            Type type = Type.GetType(fullNameTypes[i].FullName);
            string schema = entitySets[type.Name].MetadataProperties["Schema"].Value.ToString();   
        }
    }
