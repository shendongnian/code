    private static IEdmModel GetEdmModel()
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();
        builder.EntitySet<FooBarRec>("FooBarRecs");
        builder.EntitySet<Foo>("Foos");
        builder.EntitySet<Bar>("Bars");
        return builder.GetEdmModel();
    }
