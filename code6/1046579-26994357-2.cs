    public class ObjektFooListIndex : AbstractIndexCreationTask<Objekt, ObjektFooListIndex.Result> {
        public class Result {
            public string Value;
        }
        public ObjektFooListIndex() {
            Map = objekts => from objekt in objekts
                             from value in objekt.FooList
                             select new {
                                 Value = value
                             };
            Index(x => x.Value, Raven.Abstractions.Indexing.FieldIndexing.Analyzed);
        }
    }
