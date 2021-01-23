    MetaModel model = new MetaModel();
    model.RegisterContext(
        new Microsoft.AspNet.DynamicData.ModelProviders.EFDataModelProvider(
           () => new KiwiJuiceEntities()
        ),
        new ContextConfiguration() { ScaffoldAllTables = true }
    );     
