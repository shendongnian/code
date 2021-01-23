    public class Foo
    {
        public String bar { get; set; }
    }
    // instance that you want the value from
    var instance = new Foo { bar = "baz" };
    // name of property you care about
    String propName = "bar";
