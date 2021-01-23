    #region search hightligh
            public static IEnumerable<Models.Post> SearchHighligh(string input, string fieldName = "")
            {
                if (string.IsNullOrEmpty(input)) return new List<Models.Post>();
    
                var terms = input.Trim().Replace("-", " ").Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
                input = string.Join(" ", terms);
    
                return _searchHighligh(input, fieldName);
            }
            private static string getHighlight(Highlighter highlighter, StandardAnalyzer analyzer, string fieldContent)
            {
                Lucene.Net.Analysis.TokenStream stream = analyzer.TokenStream("", new StringReader(fieldContent));
                return highlighter.GetBestFragments(stream, fieldContent, 1, ".");
            }
    
    
            private static IEnumerable<Models.Post> _searchHighligh(string searchQuery, string searchField = "")
            {
                // validation
                if (string.IsNullOrEmpty(searchQuery.Replace("*", "").Replace("?", ""))) return new List<Models.Post>();
    
                // set up lucene searcher
                using (var searcher = new IndexSearcher(_directory, false))
                {
                    var hits_limit = 1000;
                    var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
    
                    IFormatter formatter = new SimpleHTMLFormatter("<span style=\"font-weight:bold; background-color:yellow;\">", "</span>");
                    SimpleFragmenter fragmenter = new SimpleFragmenter(1000);
                    QueryScorer scorer = null;
    
                    ScoreDoc[] hits;
                    // search by single field
                    if (!string.IsNullOrEmpty(searchField))
                    {
                        var parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, searchField, analyzer);
                        var query = parseQuery(searchQuery, parser);
                        scorer = new QueryScorer(query);
                        hits = searcher.Search(query, hits_limit).ScoreDocs;
    
                    }
                    // search by multiple fields (ordered by RELEVANCE)
                    else
                    {
                        var parser = new MultiFieldQueryParser
                            (Lucene.Net.Util.Version.LUCENE_30, new[] { "Title", "Body" }, analyzer);
                        var query = parseQuery(searchQuery, parser);
                        scorer = new QueryScorer(query);
                        hits = searcher.Search(query, null, hits_limit, Sort.INDEXORDER).ScoreDocs;
    
                    }
                    Highlighter highlighter = new Highlighter(formatter, scorer);
                    highlighter.TextFragmenter = fragmenter;
                    var results = _mapLuceneToDataListHighligh(hits, searcher, highlighter, analyzer);
                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
            }
            private static IEnumerable<Models.Post> _mapLuceneToDataListHighligh(IEnumerable<ScoreDoc> hits, IndexSearcher searcher, Highlighter highlighter, StandardAnalyzer analyzer)
            {
                // v 2.9.4: use 'hit.doc'
                // v 3.0.3: use 'hit.Doc'
                return hits.Select(hit => _mapLuceneDocumentToDataHighligh(searcher.Doc(hit.Doc), highlighter, analyzer)).ToList();
            }
            private static Models.Post _mapLuceneDocumentToDataHighligh(Document doc, Highlighter highlighter, StandardAnalyzer analyzer)
            {
                return new Models.Post
                {
                    Id = Convert.ToInt32(doc.Get("Id")),
                    //Title = getHighlight(highlighter, analyzer,doc.Get("Title")),
                    Title =doc.Get("Title"),
                    Body = getHighlight(highlighter, analyzer, doc.Get("Body")),
                    SiteId = Convert.ToInt16(doc.Get("SiteId")),
                    PostTypeId = Convert.ToInt32(doc.Get("PostTypeId")),
                    OwnerUserId = Convert.ToInt32(doc.Get("OwnerUserId")),
                    ParentId = Convert.ToInt32(doc.Get("ParentId")),
                    CreationDate = UTILS.Function.getDateTime((doc.Get("CreationDate")), "g")
                };
            } 
            #endregion
