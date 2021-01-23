    class Person
    {
        public string Name { get; set; }
    }
    class Test
    {
        static void Main()
        {
            var p = new Person { Name = "Tom" };
            Method(p);
            Console.WriteLine(p.Name);
        }
        static void Method(Person parameter)
        {
            parameter = new Person { Name = "Robin" };
        }
    }
