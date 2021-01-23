        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    
    
        private static void Main(string[] args)
        {
    
            var people = new List<Person>
            {
                new Person
                {
                   Id = 1,
                   Name = "James",
                   DateOfBirth = DateTime.Today.AddYears(-25),
                },
    
                new Person
                {
                    Id = 2,
                    Name = "John",
                    DateOfBirth = DateTime.Today.AddYears(-20),
                },
    
                new Person
                {
                   Id = 3,
                   Name = "Peter",
                   DateOfBirth = DateTime.Today.AddYears(-15),
                }
           };
    
           var result = people.Select(t => new
           {
               t.Name,
               DateStr = t.DateOfBirth.ToString("dd/MM/yyyy")
           }).Take(2).ToList();
    
           foreach (var r in result)
           {
              Console.WriteLine(r.Name);
              Console.WriteLine(r.DateStr);
           }
    
           Console.ReadLine();
    }
