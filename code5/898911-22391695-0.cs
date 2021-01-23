    interface IProp2
    {
        int Prop2 { get; set; }
    }
    class A : IProp2
    {
        public int Prop1 { get; set; }
        public int Prop2 { get; set; }
    }
    class B : IProp2
    {
        public int Prop2 { get; set; }
        public int Prop3 { get; set; }
    }
    // inside main
    var a = new A();
    // check if it's a member, though usually you don't need this
    Console.WriteLine(a is IProp2);  // true
