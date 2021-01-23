    // using SimpleInjector;
    // using SimpleInjector.Extensions;
    public static void Configure(Container container, string serverURL)
    {
        container.RegisterSingle<IReadOnlyMappingManager>(
            new MemoizingMappingManager(new AttributesMappingManager()));
        container.Register<ISolrDocumentPropertyVisitor, DefaultDocumentVisitor>();
        container.Register<ISolrFieldParser, DefaultFieldParser>();
        container.RegisterOpenGeneric(typeof(ISolrDocumentActivator<>), typeof(SolrDocumentActivator<>));
        container.RegisterOpenGeneric(typeof(ISolrDocumentResponseParser<>), typeof(SolrDocumentResponseParser<>));
        container.Register<ISolrFieldSerializer, DefaultFieldSerializer>();
        container.Register<ISolrQuerySerializer, DefaultQuerySerializer>();
        container.Register<ISolrFacetQuerySerializer, DefaultFacetQuerySerializer>();
        
        container.RegisterAllOpenGeneric(typeof(ISolrResponseParser<>), new[] { 
            typeof(ResultsResponseParser<>), 
            typeof(HeaderResponseParser<>), 
            typeof(FacetsResponseParser<>), 
            typeof(HighlightingResponseParser<>), 
            typeof(MoreLikeThisResponseParser<>), 
            typeof(SpellCheckResponseParser<>), 
            typeof(StatsResponseParser<>), 
            typeof(CollapseResponseParser<>) 
        });
        
        container.Register<ISolrHeaderResponseParser, HeaderResponseParser<string>>();
        container.RegisterAll<IValidationRule>(new[] { 
            typeof(MappedPropertiesIsInSolrSchemaRule), 
            typeof(RequiredFieldsAreMappedRule), 
            typeof(UniqueKeyMatchesMappingRule)
        });
        
        container.RegisterSingle<ISolrConnection>(new SolrConnection(this.serverURL));
        container.RegisterOpenGeneric(typeof(ISolrQueryResultParser<>), typeof(SolrQueryResultParser<>));
        container.RegisterOpenGeneric(typeof(ISolrQueryExecuter<>), typeof(SolrQueryExecuter<>));
        container.RegisterOpenGeneric(typeof(ISolrDocumentSerializer<>), typeof(SolrDocumentSerializer<>));
        container.RegisterOpenGeneric(typeof(ISolrBasicOperations<>), typeof(SolrBasicServer<>));
        container.RegisterOpenGeneric(typeof(ISolrBasicReadOnlyOperations<>), typeof(SolrBasicServer<>));
        container.RegisterOpenGeneric(typeof(ISolrOperations<>), typeof(SolrServer<>));
        container.RegisterOpenGeneric(typeof(ISolrReadOnlyOperations<>), typeof(SolrServer<>));
        base.Bind<ISolrSchemaParser>().To<SolrSchemaParser>();
        base.Bind<IMappingValidator>().To<MappingValidator>();
    }
