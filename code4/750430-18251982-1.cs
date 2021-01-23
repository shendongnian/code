    public class Foo
    {
        public Foo()
        {
            Bar = new List<string>();
        }
    
        public List<string> Bar { get; set; }
        public string Qux { get; set; }
    }
    var result = new Foo();
    var key = "Bar";
    
    var list = new List<object> { "A", "B" };
    
    Add(result, key, list);
