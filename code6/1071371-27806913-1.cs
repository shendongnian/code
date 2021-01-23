    using MyNamespace;   // unless you use the same namespace for both
    namespace SomeOtherNamespace
    {
        class Program
        {
            static void Main(string[] args)
            {
                var c = new MyClass();
                // alternatively, without the using statement, you can just fully qualify 
                // your class name like so:
                // var c = new MyNamespace.MyClass();
            }
        }
    }
