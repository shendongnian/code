    class Employee
    {
       public string Name { get; set; }
       public Employee Manager { get; set; }
    
       public static Employee CreateBigBoss(string name) // insert a enterprisey name here
       {
           return new Employee { Name = name, Manager = null };
       }
    
       public Employee CreateSubordinate(string name)
       {
           return new Employee { Name = name, Manager = this };
       }
    }
