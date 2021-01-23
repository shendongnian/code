    // your ns above
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var entity1 = builder.EntitySet<MyObj>("myobj");
            entity1.EntityType.HasKey(x => x.Id);
            // etc
            var model = builder.GetEdmModel();
            // tell odata that this entity object has a stream attached
            var entityType1 = model.FindDeclaredType(typeof(MyObj).FullName);
            model.SetHasDefaultStream(entityType1 as IEdmEntityType, hasStream: true);
            // etc
            config.Formatters.InsertRange(
                                        0, 
                                        ODataMediaTypeFormatters.Create(
                                                                        new MySerializerProvider(),
                                                                        new DefaultODataDeserializerProvider()
                                                                        )
                                        );
            config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
            // note: this calls config.MapHttpAttributeRoutes internally
            config.Routes.MapODataServiceRoute("ODataRoute", "data", model);
            // in my case, i want a json-only api - ymmv
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
