    namespace Test
    {
        class Program
        {
            class Myclass
            {
                public string name { get; set; }
                public decimal age { get; set; }
            }
            static void Main(string[] args)
            {
                var list = new List<Myclass> { new Myclass{name = "di", age = 0}, new Myclass{name = "marks", age = 0}, new Myclass{name = "grade", age = 0}};
                list.Where(w=> w.name == "di").ToList().ForEach(i => i.age = 10);
                list.ForEach(i => Console.WriteLine(i.name + ":" + i.age));
            }
        }
    }
