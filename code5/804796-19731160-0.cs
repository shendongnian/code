    namespace A
    {
        public enum ABC
        {
        }
        public class ClassA
        {
            static ClassA()
            { }
            public static bool f_name
            {
               get { return true; }
            }
    
            //All the rest of the functions are also static
        }
    }
    
    namespace B
    {
        using A;
        public partial class ClassB
        {
            /// changed this to static to match access on class A
            private static bool x;
            public ClassB()
            { }
            static void Main()
            {
                x = ClassA.f_name;
            }
        }
    }
