    public class Person
    {
     // default constructor
     public Person()
     {
     }
    
     public Person(string name, int age)
     {
      Name = name;
      Age = age;
     }
    
     public string Name {get;set;}
     public int Age {get;set;}
    }
    
    public class Employee
    {
     private Person _person;
    
     // default constructor
     // Option 1;
     public Employee()
     {
      // create instance of person injecting name and age on instantiation
      Person = new Person("John Doe", "42");
     }
    
     // Option 2
     public Employee(string name, int age)
     {
      // create instance with default constructor 
      Person = new Person();
      
      // set properties once object is created.
      Person.Name = name;
      Person.Age = age;
     }
    
    }
