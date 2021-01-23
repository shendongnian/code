    class Employee
    {
     [Computed]
     public string FullName
     {
      get { return FirstName + " " + LastName; }
     }
     public string LastName { get; set; }
     public string FirstName { get; set; }
    }
