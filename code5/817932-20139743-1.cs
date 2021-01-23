    var results = solr.Query(new SolrQueryByField("text", searchString),
            new QueryOptions
            {
                Highlight = new HighlightingParameters
                {
                    Fields = new[] { "*" },
                }
            });
