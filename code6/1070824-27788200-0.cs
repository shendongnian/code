    // namespace X { class Foo {} }
    Foo f = new Foo();
    Console.WriteLine(f); // Prints "X.Foo"
    // http://ideone.com/YyfIqX
    Console.WriteLine(new object[0]); // Prints System.Object[]
    Console.WriteLine(new int[0]); // Prints System.Int32[]
    Console.WriteLine(new string[0]); // Prints System.String[]
