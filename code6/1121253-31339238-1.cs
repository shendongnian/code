    ResultTable rtSharePointSearchResult = new ResultTable();
    KeywordQuery query = new KeywordQuery(clientContext);
    query.QueryText = "Keywords";
    query.TrimDuplicates = false;
    SearchExecutor searchExecutor = new SearchExecutor(clientContext);
    ClientResult<ResultTableCollection> results = searchExecutor.ExecuteQuery(query);
    clientContext.ExecuteQuery();
    rtSharePointSearchResult = results.Value[0];
