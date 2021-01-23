        var catalog = new COMAdmin.COMAdminCatalog();
        catalog.Connect(System.Environment.MachineName);
        var coll = (COMAdmin.ICatalogCollection)catalog.GetCollection("LocalComputer");
        coll.Populate();
        var catalogObject = (COMAdmin.ICatalogObject)coll.Item[0];
        var timout = catalogObject.Item[0].Value["TransactionTimeout"];
