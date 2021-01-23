    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    var persons = context.Database.SqlQuery<Person>(@"Select id, name from persons");
