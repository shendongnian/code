    class Names
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    var name = new Names {FirstName = "John", LastName = "Saunders"};
    Console.WriteLine(name);  // Will display "Tester.cs.Names"
