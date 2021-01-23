    // using SimpleInjector;
    public static void Configure(Container container, string serverURL)
    {
        container.RegisterInstance<IReadOnlyMappingManager>(
            new MemoizingMappingManager(new AttributesMappingManager()));
        container.Register<ISolrDocumentPropertyVisitor, DefaultDocumentVisitor>();
        container.Register<ISolrFieldParser, DefaultFieldParser>();
        container.Register(typeof(ISolrDocumentActivator<>), typeof(SolrDocumentActivator<>));
        container.Register(typeof(ISolrDocumentResponseParser<>), typeof(SolrDocumentResponseParser<>));
        container.Register<ISolrFieldSerializer, DefaultFieldSerializer>();
        container.Register<ISolrQuerySerializer, DefaultQuerySerializer>();
        container.Register<ISolrFacetQuerySerializer, DefaultFacetQuerySerializer>();
        
        container.Collection.Register(typeof(ISolrResponseParser<>), new[] { 
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
        container.Collection.Register<IValidationRule>(new[] { 
            typeof(MappedPropertiesIsInSolrSchemaRule), 
            typeof(RequiredFieldsAreMappedRule), 
            typeof(UniqueKeyMatchesMappingRule)
        });
        
        container.RegisterInstance<ISolrConnection>(new SolrConnection(this.serverURL));
        container.Register(typeof(ISolrQueryResultParser<>), typeof(SolrQueryResultParser<>));
        container.Register(typeof(ISolrQueryExecuter<>), typeof(SolrQueryExecuter<>));
        container.Register(typeof(ISolrDocumentSerializer<>), typeof(SolrDocumentSerializer<>));
        container.Register(typeof(ISolrBasicOperations<>), typeof(SolrBasicServer<>));
        container.Register(typeof(ISolrBasicReadOnlyOperations<>), typeof(SolrBasicServer<>));
        container.Register(typeof(ISolrOperations<>), typeof(SolrServer<>));
        container.Register(typeof(ISolrReadOnlyOperations<>), typeof(SolrServer<>));
        container.Register<ISolrSchemaParser, SolrSchemaParser>();
        container.Register<IMappingValidator, MappingValidator>();
    }
