    public class ObjektFooListIndex : AbstractIndexCreationTask<Objekt, ObjektFooListIndex.Result> {
        public class Result {
            public string[] Values;
        }
        public ObjektFooListIndex() {
            Map = objekts => from objekt in objekts
                             select new {
                                 Values = objekt.FooList.Select(x => x.Value).ToArray()
                             };
            Index(x => x.Values, Raven.Abstractions.Indexing.FieldIndexing.NotAnalyzed);
        }
    }
