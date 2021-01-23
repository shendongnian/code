    var results = ElasticClient
        .Search<ClusterInstance>(body => body
            .AllIndices()
            .Size(500)
            .Query(query => query
                .Bool(@bool => @bool
                    .Must(must => must
                        .QueryString(qs => qs
                            .Query("MyTestName"))))));
    resultobject.clusterinstances = results.Documents.ToList();
