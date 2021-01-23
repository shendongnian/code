    class Foo
    {
        public int Bar1 { get; set; }
        public int Bar2 { get; set; }
        public double Foobar1 { get; set; }
        public double Foobar2 { get; set; }
        public string BufferProperty { get; set; }
    }
    var obj = new Foo() {Bar1 = 2, Bar2 = 4, Foobar1 = 5, Foobar2 = 6};
    var obj2 = new Foo() { Bar1 = 2, Bar2 = 4, Foobar1 = 5, Foobar2 = 7 };
    var list = new List<Foo>();
    list.Add(obj);  // 17
    list.Add(obj2); // 18
    Console.WriteLine(list.Sum(x => sumNumericalProperties(x))); // 35
