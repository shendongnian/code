    using (Directory directory = FSDirectory.Open("LuceneIndex"))
    using (Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
    using (IndexWriter writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
    using (IndexReader reader = writer.GetReader())
    {
        writer.DeleteAll();
        var doc = new Lucene.Net.Documents.Document();
        doc.Add(new Lucene.Net.Documents.Field("ID", "1", Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED, Lucene.Net.Documents.Field.TermVector.NO));
        doc.Add(new Lucene.Net.Documents.Field("txt", "text", Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED, Lucene.Net.Documents.Field.TermVector.NO));
        writer.AddDocument(doc);
        writer.Optimize();
        writer.Flush(true, true, true);
        Query query = new TermQuery(new Term("txt", "text"));
        //Setup searcher
        IndexSearcher searcher = new IndexSearcher(directory);
        //Do the search
        TopDocs hits = searcher.Search(query, 10);
    }
