    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.Function
    
    ActionConfiguration PutNewEnumTypeInOfferBase = modelBuilder.Action("PutNewEnumTypeInOfferBase");
    PutNewEnumTypeInOfferBase .Parameter<string>("Title");
    PutNewEnumTypeInOfferBase .ReturnsFromEntitySet<Movie>("Movies");
    builder.Function("GetSalesTaxRate")
                .Returns<double>()
                .Parameter<string>("state");
