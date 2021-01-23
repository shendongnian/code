    public struct Person
    {
        public string Name { get; set; }
    }
    List<Person> list1 = new List<Person> 
    { 
        new Person { Name = "A" }, 
        new Person { Name = "B" },  
    };
    List<Person> list2 = new List<Person> 
    {
        new Person { Name = "A" }, 
    };
    var newList = list1.Except(list2).ToList(); 
       // "B" only
