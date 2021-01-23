    string sortText = Enum.GetName(typeof(SortableFields), sortBy);
            SortField field = new SortField(sortText, SortField.STRING, sortDesc);
            var sortByField = new Lucene.Net.Search.Sort(field);
            TopFieldCollector collector = Lucene.Net.Search.TopFieldCollector.Create(sortByField, MaxSearchResultsReturned, false, false, false, false);
            using (Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
            {
                var queryParse = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, IndexFields.FullText, analyzer);
                queryParse.AllowLeadingWildcard = true;
                Query query = queryParse.Parse(searchText);
                using (var searcher = new IndexSearcher(directory, true))
                {
                    searcher.Search(query, collector);
                    totalRows = collector.TotalHits;
                    TopDocs matches = collector.TopDocs(skip, take);
                    // convert results to known objects
                    var results = new List<SearchResult>();
                    foreach (var item in matches.ScoreDocs)
                    {
                        int id = item.Doc;
                        Document doc = searcher.Doc(id);
                        SearchResult result = new SearchResult();
                        result.ID = doc.GetField("ID").StringValue;
                        results.Add(result);
                    }
                }
            }
                  return results;
