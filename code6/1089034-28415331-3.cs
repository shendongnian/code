     public class Employee
    {
      [NotMapped]
      public bool IsSupervisor
      {
         get
         {
             return Employess.Count>0
         }
      }
    }
