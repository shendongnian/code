    public class Employee
    {
      public string EmployeeId    ;
      public DateTime ProjectDate ;
      public string   ProjectCode ;
    }
    
    public class EmployeeRollup
    {
      public string EmployeeId        ;
      public DateTime ProjectDateFrom ;
      public DateTime ProjectDateThru ;
      public string[] ProjectCodes    ;
    }
    
    class Program
    {
      static void Main(string[] args)
      {
        List<Employee>       details = new List<Employee>() ;
        List<EmployeeRollup> summary =
          details
          .GroupBy( e => e.EmployeeId , StringComparer.OrdinalIgnoreCase )
          .Select( g => new EmployeeRollup {
            EmployeeId      = g.Key ,
            ProjectDateFrom = g.Min( e => e.ProjectDate ) ,
            ProjectDateThru = g.Max( e => e.ProjectDate ) ,
            ProjectCodes    = g.Select( e => e.ProjectCode )
                                              .Distinct( StringComparer
                                              .OrdinalIgnoreCase )
                                              .ToArray() ,
          })
          .ToList()
          ;
      }
    }
