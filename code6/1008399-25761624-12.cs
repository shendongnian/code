        public class Class1 
        {
            internal static string MYVAR = "10";
            private string _myVar = "10";
            public string MyVar
            {
                get
                {
                    return _myVar;
                }
                set
                {
                    _myVar = value;
                    MyVar = value;
                }
            }
        }
        public class Class2 : Class1
        {
            public new string MyVar
            {
                get
                {
                    return Class1.MYVAR;
                }
            }
            string MyVar2 { get; set; }
        }
