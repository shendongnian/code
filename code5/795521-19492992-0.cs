    class Info
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<string> List { get; set; }
        }
    
        class MyClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string s { get; set; }
        }
    
        static void Main(string[] args)
        {
            var infos = new List<Info> { new Info { Id = 1, Name = "c1", List = new List<string> { "A", "B" } }, new Info { Id = 2, Name = "c2", List = new List<string> { "A", "B" } } };
            var myClasses = new List<MyClass>();
            foreach (var info in infos)
            {
                myClasses.AddRange(info.List.Select(a => new MyClass { Id = info.Id, Name = info.Name, s = a }));
            }
        }
