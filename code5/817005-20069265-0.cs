    public class Test2
    {
        public int a { get; set; }
        public int b { get; set; }
    }
    var list = testList
       .Select(t => new Test2{ a = t.a, b = t.b } )
       .ToList();
