    public void CreateIndex(string indexName, string json)
    {
        ElasticClient client = GetClient();
        var response = _client.Raw.IndicesCreatePost(indexName, json);
        if (!response.Success || response.HttpStatusCode != 200)
        {
            throw new ElasticsearchServerException(response.ServerError);
        }
    }
