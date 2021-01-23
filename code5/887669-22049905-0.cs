    var metadata = ((IObjectContextAdapter)db).ObjectContext.MetadataWorkspace;
        var tables = metadata.GetItemCollection(DataSpace.SSpace)
          .GetItems<EntityContainer>()
          .Single()
          .BaseEntitySets
          .OfType<EntitySet>()
          .Where(s => !s.MetadataProperties.Contains("Type") 
            || s.MetadataProperties["Type"].ToString() == "Tables");
