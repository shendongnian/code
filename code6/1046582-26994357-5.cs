    public class ObjektFooListIndex : AbstractIndexCreationTask<Objekt, ObjektFooListIndex.Result> {
        public class Result {
            public string Value;
        }
        public ObjektFooListIndex() {
            Map = objekts => from objekt in objekts
                             from foo in objekt.FooList
                             select new {
                                 Value = foo.Value
                             };
        }
    }
