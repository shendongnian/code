    var client = new ElasticClient();
    var seriesSearch = new SearchDescriptor<Series>();
    seriesSearch.Filter(f => f
        .Term<Role>(t => t.ReleasableTo.First(), Role.Visitor))
        .SortDescending(ser => ser.EndDate)
        .Size(1));
    string searchJson = Encoding.UTF8.GetString(client.Serializer.Serialize(seriesSearch));
