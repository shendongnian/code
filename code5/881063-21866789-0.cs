    // for code-first
    var Container = this.Entities.MetadataWorkspace.GetEntityContainer("CodeFirstDatabase", DataSpace.SSpace);
    // db-first
    var Container = this.Entities.MetadataWorkspace.GetEntityContainer("DbFirstModelStoreContainer", DataSpace.SSpace);
    var schemaName = Container.GetEntitySetByName(this.Entities.PRODUCT.EntitySet.Name, true).Schema
    // or
    var set = Container.GetEntitySetByName(this.Entities.PRODUCT.EntitySet.Name, true);
    var schemaName = Set.MetadataProperties["Schema"].Value;
