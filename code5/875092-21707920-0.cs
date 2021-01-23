    var result = solr.Query(solrQuery, new SolrNet.Commands.Parameters.QueryOptions
    {
        Rows = 100, // 
        Start = 0,
        OrderBy = new[] { new SortOrder("score", Order.DESC), new SortOrder("ID", Order.DESC) },
    });
