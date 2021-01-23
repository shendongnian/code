            V1APIConnector dataConnector = new V1APIConnector("YourVersionOne/rest-1.v1/","username", "password");
            V1APIConnector metaConnector = new V1APIConnector("YourVersionOne/meta.v1/");
 
            IMetaModel metaModel = new MetaModel(metaConnector);
            IServices services = new Services(metaModel, dataConnector);
            IAssetType actualType = metaModel.GetAssetType("Actual");
           
            IAttributeDefinition dateAttribute = actualType.GetAttributeDefinition("Date");
            IAttributeDefinition valueAttribute = actualType.GetAttributeDefinition("Value");
            IAttributeDefinition workitemAttribute = actualType.GetAttributeDefinition("Workitem");
            Query query = new Query(actualType);
           
            query.Selection.Add(dateAttribute);
            query.Selection.Add(valueAttribute);
   
            FilterTerm term = new FilterTerm(workitemAttribute);
            term.Equal("Story:114192");
            query.Filter = term;
      
            QueryResult result = services.Retrieve(query);
