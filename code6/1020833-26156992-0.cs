        public class NoNullsInjection : ConventionInjection
        {
            protected override bool Match(ConventionInfo c)
            {
                return c.SourceProp.Name == c.TargetProp.Name
                        && c.SourceProp.Value != null;
            }
        }
        class A
        {
            public string a { get; set; }
            public string b { get; set; }
        }
       
        static void Main(string[] args)
        {
            A a1 = new A() { a = "123" };
            A a2 = new A() { b = "456" };
            A c = new A();
            c.InjectFrom(new NoNullsInjection(),a1,a2); 
            // "c" now have a="123", b="456" 	 
        }
