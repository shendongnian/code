    var results = solr.Query(new SolrQueryByField("author", searchString),
            new QueryOptions
            {
                Highlight = new HighlightingParameters
                {
                    Fields = new[] { "author" },
                }
            });
