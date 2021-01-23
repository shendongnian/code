    var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
        .DefaultIndex("index1")
        .DisableDirectStreaming();
    
    var response = new ElasticClient(settings)
               .Search<object>(s => s.AllIndices().AllTypes().MatchAll());
    if (response.ApiCall.ResponseBodyInBytes != null)
    {
        var responseJson = System.Text.Encoding.UTF8.GetString(response.ApiCall.ResponseBodyInBytes);
    }
