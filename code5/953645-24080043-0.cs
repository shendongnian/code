    public class Person : EntityBase
    {
        public string Name {get; set;}
        // other properties
    }
    public class Employee : Person
    {
         public decimal Salary {get; set; }
    }
