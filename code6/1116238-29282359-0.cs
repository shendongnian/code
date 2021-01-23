    public class A {
        ///<summary>Creates an instance of A, or of a subclass of A</summary>
        public static A Create<T>() where T : A {
            A result = (A)FormatterServices.GetUninitializedObject(typeof(T));
            result.defaultInit();
            return result;
        }
        public A() {
            defaultInit();
        }
        private void defaultInit() {
            // field assignments ...
            // default constructor code ...
        }
    }
    public class B : A {
        string Stuff { get; set; }
        public B(string stuff) {
            Stuff = stuff;
        }
    }
