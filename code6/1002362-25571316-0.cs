    public struct Foo
    {
        public string Bar { get; set; }
    }
    Foo[] foos = new Foo[99];
    Foo foundFoo = foos[0]; // This is equivalent to your find statement... setting a foundFoo local variable to a Foo struct
    string foundBar = foos[0].Bar; // This is another way to get to what you're trying to accoomplish, setting a string value representation of your found object.
    Console.WriteLine(foundFoo); // Doesn't know how to deal with printing out a Foo struct - simply writes [namespace].Foo
    Console.WriteLine(foundFoo.Bar); // Outputs Foo.Bar value
    Console.WriteLine(foundBar); // Outputs Foo.Bar value
