    public static class ElasticSearchClientHelper
    {
        public static ISearchResponse<T> SearchByJson<T>(this IElasticClient client, string json, string indexName, Dictionary<string, object> queryStringParams = null) where T : class
        {
            var qs = new Dictionary<string, object>()
            {
                {"index", indexName}
            };
            queryStringParams?.ForEach(pair => qs.Add(pair.Key, pair.Value));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var searchRequest = client.Serializer.Deserialize<SearchRequest>(stream);
                ((IRequestParameters)((IRequest<SearchRequestParameters>)searchRequest).RequestParameters).QueryString = qs;
                return client.Search<T>(searchRequest);
            }
        }
    }
