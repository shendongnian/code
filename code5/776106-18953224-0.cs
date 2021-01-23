    public class Bar
        {
            public string Gar { get; set; }
    
            public static explicit operator Foo(Bar bar)
            {
                return new Foo(bar.Gar);
            }
        }
    
        public class Foo
        {
            public string Gar { get; set; }
    
            public Foo() { }
    
            public Foo(string gar) { Gar = gar; }
        }
    
    static void Main(string[] args)
            {
    
                List<Bar> bars = new List<Bar>();
                for (int i = 0; i < 10; i++)
                    bars.Add(new Bar() { Gar = i.ToString() });
    
                var result = bars.Cast<Foo>();
            }
