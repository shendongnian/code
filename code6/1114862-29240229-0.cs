            var elasticSearchVideoQueryBuilder = new ElasticSearchVideoQueryBuilder();
            var descriptor = elasticSearchVideoQueryBuilder.BuildDocumentQuery(new ElasticSearchVideoParameters());
    
            var settings = new ConnectionSettings(new Uri("http://localhost:123"));
            var client = new ElasticClient(settings);
    
            var jsonString = Encoding.UTF8.GetString(client.Serializer.Serialize(descriptor));
