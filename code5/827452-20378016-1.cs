        void Main() {
            Test t = new Test();
            Type tType = t.GetType();
            foreach (PropertyInfo prop in tType.GetProperties()) {
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
