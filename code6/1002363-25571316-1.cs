    public struct Foo
    {
        public string Bar { get; set; }
    }
    public struct FooTwo
    {
        public string Bar { get; set; }
        public override string ToString()
        {
            return "This is how to represent a Foo2 as string: " + Bar;
        }
    }
    Foo[] foos = new Foo[99];
    Foo foundFoo = foos[0]; // This is equivalent to your find statement... setting a foundFoo local variable to a Foo struct
    string foundBar = foos[0].Bar; // This is another way to get to what you're trying to accoomplish, setting a string value representation of your found object.
    Console.WriteLine(foundFoo); // Doesn't know how to deal with printing out a Foo struct - simply writes [namespace].Foo
    Console.WriteLine(foundFoo.Bar); // Outputs Foo.Bar value
    Console.WriteLine(foundBar); // Outputs Foo.Bar value
    FooTwo foo2 = new FooTwo();
    foo2.Bar = "test bar";
    Console.WriteLine(foo2); // outputs: "This is how to represent a Foo2 as string: test bar"
