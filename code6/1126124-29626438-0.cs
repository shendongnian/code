    class Program
    {
        private class Foo
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
        }
        private class Bar
        {
            public string E { get; set; }
            public string F { get; set; }
            public string G { get; set; }
        }
        static void Main(string[] args)
        {
            var list = new List<Foo>
            {
                new Foo { A = "a", B = "a", C = "a" },
                new Foo { A = "a2", B = "b2", C = "c2" },
                new Foo { A = "a3", B = "b3", C = "c3" },
            };
            var list2 = new List<Bar>
            {
                new Bar { E = "a", F = "a", G = "a" },
                new Bar { E = "a2", F = "b2", G = "c2" },
                new Bar { E = "a3", F = "b3", G = "c3" },
            };
            var q1 = Filter(list.AsQueryable(), "a");
            var q2 = Filter(list2.AsQueryable(), "a");
            foreach (var x in q1)
            {
                Console.WriteLine(x);
            }
            foreach (var x in q2)
            {
                Console.WriteLine(x);
            }
            var queryable = list.Select(p => new
            {
                X = p.A,
                Y = p.B,
                Z = p.C
            }).AsQueryable();
            var q3 = Filter(queryable, "a"); 
            foreach (var x in q3)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }
        private static IQueryable<object> Filter(IQueryable<object> list, string value)
        {
            foreach (var prop in list.ElementType.GetProperties())
            {
                var prop1 = prop;
                list = list.Where(l => Equals(prop1.GetValue(l, null), value));
            }
            return list;
        }
    }
