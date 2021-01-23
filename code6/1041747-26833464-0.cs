    var docDbQueryable = documentClient.CreateDocumentQuery<Document>(collectio‌​nSelfLink, query, options).AsDocumentQuery();
    var docDbResults = new List<Document>();
    do
    {
    	var batchResult = await docDbQueryable.ExecuteNextAsync<Document>(‌​);;
    	docDbResults.AddRange(batchResult);
    }
    while (docDbQueryable.HasMoreResults);
    return docDbResults;
