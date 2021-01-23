     List<QueryContainer> shoudQuery = new List<QueryContainer>();
    List<QueryContainer> mustQuery = new List<QueryContainer>();
    
    
    shoudQuery.Add(new MultiMatchQuery()
        {
            //your Query
        });
    mustQuery.Add(new termQuery()
        {
           Field = "category",
           value= "infopage",    
        });
    
    
    QueryContainer queryContainer = new BoolQuery
            {
                 Should = shoudQuery.ToArray(),
                 Must = mustQuery.ToArray(),
                 MinimumShouldMatch = 1,
    
             };
    
    
    var result = Client.Search(s => s.Size(resultSize).Query(q => queryContainer)
