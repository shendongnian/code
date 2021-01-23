    class Program {
        static void Main(string[] args) {
            var obj = new Example();   // fine
        }
    }
    struct Foo { }
    class Example : FSharpLibrary.FSharpType<Foo> { }
