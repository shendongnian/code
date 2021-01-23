    class TVM : Lucene.Net.Index.TermVectorMapper
    {
        public HashSet<Lucene.Net.Index.Term> FoundTerms = new HashSet<Lucene.Net.Index.Term>();
        HashSet<Lucene.Net.Index.Term> _AllTerms = new HashSet<Lucene.Net.Index.Term>();
        public TVM(Lucene.Net.Search.Query q, Lucene.Net.Index.IndexReader r) : base()
        {
            q.Rewrite(r).ExtractTerms(_AllTerms);
        }
        public override void SetExpectations(string field, int numTerms, bool storeOffsets, bool storePositions)
        {
        }
        public override void SetDocumentNumber(int documentNumber)
        {
            FoundTerms.Clear();
        }
        public override void Map(string term, int frequency, Lucene.Net.Index.TermVectorOffsetInfo[] offsets, int[] positions)
        {
            var fountTerm = _AllTerms.FirstOrDefault(x => x.Text == term);
            if (fountTerm != null) FoundTerms.Add(fountTerm);
        }
    }
    void TermVectorMapperTest()
    {
        var dir = new Lucene.Net.Store.RAMDirectory();
        //Index
        using (var writer = new Lucene.Net.Index.IndexWriter(dir, new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30), true, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED))
        {
            Lucene.Net.Documents.Document d = null;
            d = new Lucene.Net.Documents.Document();
            d.Add(new Lucene.Net.Documents.Field("field1", "microscope aaa", Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
            d.Add(new Lucene.Net.Documents.Field("field2", "microswave bbb", Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
            writer.AddDocument(d);
            d = new Lucene.Net.Documents.Document();
            d.Add(new Lucene.Net.Documents.Field("field2", "microsoft ccc", Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
            writer.AddDocument(d);
            d = new Lucene.Net.Documents.Document();
            d.Add(new Lucene.Net.Documents.Field("field1", "zzz", Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
            writer.AddDocument(d);
        }
        //Search
        using (var indexReader = Lucene.Net.Index.IndexReader.Open(dir, true))
        {
            var indexSearcher = new Lucene.Net.Search.IndexSearcher(indexReader);
            var queryParser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_30, "field1", new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));
            queryParser.MultiTermRewriteMethod = Lucene.Net.Search.MultiTermQuery.SCORING_BOOLEAN_QUERY_REWRITE;
            var query = queryParser.Parse("field1:micro* field2:micro*");
            var results = indexSearcher.Search(query, 5);
            TVM tvm = new TVM(query, indexReader);
            foreach(var sd in results.ScoreDocs)
            {
                Console.Write("DOCID:" + sd.Doc + " > ");
                indexReader.GetTermFreqVector(sd.Doc, tvm);
                Console.WriteLine(String.Join(" ", tvm.FoundTerms.Select(term => "[" + term.Field + ":" + term.Text + "]")));
            }
        }
    }
