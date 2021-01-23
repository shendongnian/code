    public class MyClass
    {
        private static string _prop1;
        public static string Prop1
        {
            get
            {
                // Your initial code to run whenever value is retrived (like........... something = Prop2;)
                // { 
                //   code block
                // }
                return _prop1;
            }
            set
            {
                // Your initial code to run whenever something is assigned (like........... Prop2 = something;)
                // { 
                //   code block
                // }
                _prop1 = value;
            }
        }
        private static string _prop2;
        public static string Prop2
        {
            get
            {
                // Your initial code to run whenever value is retrived (like........... something = Prop2;)
                // { 
                //   code block
                // }
                return _prop2;
            }
            set
            {
                // Your initial code to run whenever something is assigned (like........... Prop2 = something;)
                // { 
                //   code block
                // }
                _prop2 = value;
            }
        }
    }
