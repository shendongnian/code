        static void Main(string[] args) {
            var lambda = new Func<Foo, bool>(foo => 
                   (foo.Bar * 5 + foo.Baz * 2 > 7)
                || (foo.Bar * 5 + foo.Baz * 2 < 3) 
                || (foo.Bar * 5 + 3 == foo.Xyz));
            var obj = new Foo() { Bar = 1, Baz = 2, Xyz = 3 };
            var result = lambda(obj);
            Console.WriteLine(result);
        }
    }
    class Foo {
        public int Bar { get; internal set; }
        public int Baz { get; internal set; }
        public int Xyz { get; internal set; }
    }
