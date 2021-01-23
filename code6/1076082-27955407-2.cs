    public class Foo
    {
        static void Main(string[] args)
        {
            // main point of entry
            //new instance of Bar
            var bar = new Bar();
            //call method defined on Bar
            bar.SomeMethod("Hey", "There");
        }
        public static void MethodFromFoo(string param1, string param2)
        {
            Console.WriteLine(param1 + ' ' + param2);
            Console.ReadLine();
        }
    }
    public class Bar
    {
        public void SomeMethod(string param1, string param2)
        {
            // call method on Foo -- no need for new instance (static)
            Foo.MethodFromFoo(param1, param2);
        }
    }
