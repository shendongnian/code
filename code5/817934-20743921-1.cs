     var results = solr.Query(string.Format("{0}:{1}", "text", searchString),
                new QueryOptions
                {
                    Highlight = new HighlightingParameters
                    {
                        Fields = new[] { "*" },
                    }
                });
