    public class Person
    {
        public string Name;
        public int age;
    }
    var People = new List<Person>
    {
        new Person {Name = "Jack", Age = 15},
        new Person {Name = "James" , Age = 19},
        new Person {Name = "John" , Age = 14},
        new Person {Name = "Jodie" , Age = 21},
        new Person {Name = "Jessie" , Age = 19}
    }
    People.Take(2);
