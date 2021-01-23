    public class Foo
    {
        static void Main(string[] args) // main point of entry
        {
            //new instance of Bar
            var bar = new Bar();
            //call method defined on this class
            MethodFromFoo();
            //call SomeMethod() defined on Bar
            bar.SomeMethod("Passing a string", "To a Method on Bar!");
        }
        static void MethodFromFoo()
        {
            Console.WriteLine("This is From Foo");
        }
    }
    public class Bar
    {
        public void SomeMethod(string param1, string param2) // must define parameter types e.g. string
        {
            Console.WriteLine(param1 + ' ' + param2);
            Console.ReadLine(); // pause execution
        }
    }
