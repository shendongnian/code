    class Person
    {
        public string Name {get;set;}
    }
    var people = new Dictionary<string, Person>();
    people.Add("Steve", new Person { Name = "Steve"});
    var theSteve = people["Steve"];
