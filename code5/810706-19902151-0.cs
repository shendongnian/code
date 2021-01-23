    class HumanReport
    {
        int Name {get; set;}
        int Age {get; set;} 
    }
    class Student : HumanReport
    {
      int Class {get; set;}
    }
    class Employee : HumanReport
    {
      int Salary{get; set;}
    }
