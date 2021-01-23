        void Main() {
            var t = new Test();
            var tType = t.GetType();
            foreach (var prop in tType.GetProperties()) {
                prop.Name.Dump();
            }
        }
        
        public class Test {
            public string prop1 { get; set; }
            public string prop2 { get; set; }
            public Test() {
                prop1 = "Property 1";
                prop2 = "Property 2";
            }
        }
