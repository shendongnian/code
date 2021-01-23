    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    builder.EntitySet<ProductDto>("ProductDtos");
    builder.EntitySet<ProductType>("ProductType");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
