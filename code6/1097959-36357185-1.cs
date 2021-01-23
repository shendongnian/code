    var cs = String.Format("metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;provider=System.Data.SqlClient;provider connection string=\"\"", "TestModel");
    using (var ctx = new TestDBEntities(cs)) {
        var metadata = ((IObjectContextAdapter)ctx).ObjectContext.MetadataWorkspace;
        // no throw here
        Console.WriteLine(metadata);                
    }
