    public class Foo
    {
        public string Bar { get; set; }
        public static implicit operator Foo(string s)
        {
            return new Foo() { Bar = s };
        }
    }
