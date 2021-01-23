    public class Employee
    {
       [DebuggerDisplay("Name= {Name}")]
       public string Name{get;set;}
    
       public Employee(string name)
       {
           Name = name;
       }
    }
