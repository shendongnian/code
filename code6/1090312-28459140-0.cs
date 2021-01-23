    public static class Helper
    {
        public static object Search<T>(T classToPass)
        {
            SearchElasticClient
                                  .Search<T>(body => body
                                    .AllIndices()
                                    .Size(500)
                                    .Query(query => query
                                        .Bool(@bool => @bool
                                            .Must(must => must
                                                .QueryString(qs => qs
                                                    .Query("XXX"))))));
        }
    }
