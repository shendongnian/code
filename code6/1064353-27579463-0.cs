    public class Person
    {
        public DateTime CreateDate {get;set;}
    }
    
    public class Employee
    {
        public DateTime CreateDate {get;set;}
        public virtual Person BasedOnPerson {get;set;}
    }
