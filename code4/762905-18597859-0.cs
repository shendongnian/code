    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    var list = new List<Person>
               {
                   new Person
                   {
                      FirstName = "Bob",
                      LastName = "Carlson"
                   },
                   new Person
                   {
                      FirstName = "Elizabeth",
                      LastName = "Carlson"
                   },
               };
    // Directly               
    list[1].FirstName = "Liz";
    // In a loop
    foreach(var person in list)
    {
        if(person.FirstName == "Liz")
        {
            person.FirstName = "Lizzy";
        }
    }
