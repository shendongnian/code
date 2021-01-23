     class Persons
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var personCollection = new List<Persons>
                {
                    new Persons {Id = 1, Name = "Manu"},
                    new Persons {Id = 2, Name = "Lijo"},
                    new Persons {Id = 3, Name = "John"},
                    new Persons {Id = 4, Name = null},
                    new Persons {Id = 5, Name = null},
                };
    
                List<string> personsNames =
                    personCollection.Where(x => x.Name != null && x.Name.Contains("j")).Select(x => x.Name).ToList();
    
    
                foreach (var personame in personsNames)
                {
                    Console.WriteLine(personame);
                }
    
                Console.ReadLine();
            }
        }
