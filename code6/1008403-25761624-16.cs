        public class Class1 
        {
            internal static int Myvar;
            private int _myVar;
            public int MyVar1
            {
                get{return this.GetType().IsSubclassOf(typeof(Class1)) ? Myvar : _myVar;}
                set{_myVar = value;Myvar = value;}
            }
        }
        public class Class2 : Class1
        {
            public int MyVar2 { get; set; }
        }
