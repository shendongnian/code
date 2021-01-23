    class Foo
    {
        public int Bar1 { get; set; }
        public int Bar2 { get; set; }
        public double Foobar1 { get; set; }
        public double Foobar2 { get; set; }
        public string BufferProperty { get; set; }
    }
    var obj = new Foo() { Bar1 = 2, Bar2 = 4, Foobar1 = 5, Foobar2 = 6 };
    Console.WriteLine(sumNumericalProperties(obj)); // 17
