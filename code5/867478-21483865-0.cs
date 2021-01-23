    string strQuery = "(ParentId:\"Thread\") OR (DataId:\"Thread\")"; 
    // or use * for contains instead of double quotes
    var query = new SolrQuery(strQuery);
    SortOrder sortOrder = new SortOrder("ParentId");
    var solrQueryResult = solr.Query(query, new QueryOptions
        {
            Rows = 100, //Max Rows returned
            Start = 0,
            OrderBy = new[] { sortOrder }, //If you want the ordered result
        });
     var list = solrQueryResult.ToList();//if you want list
