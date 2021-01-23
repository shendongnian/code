    public class Foo
    {
        static void Main(string[] args) // main point of entry
        {
            //new instance of Bar
            var bar = new Bar();
            //call SomeMethod() defined on Bar
            bar.SomeMethod("hey", "There");
        }
    }
    public class Bar
    {
        public void SomeMethod(string param1, string param2)
        {
            Console.WriteLine(param1 + ' ' + param2);
            Console.ReadLine(); // pause execution
        }
    }
