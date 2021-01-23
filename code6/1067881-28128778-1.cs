    class Program {
        static void Main(string[] args) {
            var obj = new Example();   // fine
        }
    }
    class Foo { }
    class Example : FSharpLibrary.FSharpType<Foo> { }
