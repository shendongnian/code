    namespace ConsoleApplication2
    {
    
        class MyClass
        {
            private string _state;
            public override int GetHashCode()
            {
                
                return _state.MyCustomHasCode();
            }
        }
        public static class Program
        {
            public static int MyCustomHasCode(this string str)
            {
                // return "your own hashcode implementation
            }
            static void Main(string[] args)
            {
    
            }
        }
    }
