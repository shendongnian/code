    class Person
    {
        public string Name { get; set; }
    
        public int Age { get; set; } // or of type string if you will
    }
    
    List<Person> personList = new List<Person>
    {
        new Person { Name = "Vignesh", Age = 26 }
    };
