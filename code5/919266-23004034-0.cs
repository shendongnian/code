    public class SqlRepository : IRepository
    {
      public List<EmployeeModel> GetEmployees()
      {
       // get it from SQL using ADO.NET or Linq2Sql
       // transform into EmployeeModel using Automapper/manual and return.
      }
    }
    
    public class WebServiceRepository : IRepository
    {
      private readonly ProxyClient _proxy; // or helper
     
      public List<EmployeeModel> GetEmployees()
      {
       // get it from the ASMX using Proxy Helpers with return type as data contracts.
       // transform the data contracts into EmployeeModel using Automapper/manual and return.
      }
    }
