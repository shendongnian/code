    Public class Employee
    {
        public int EmployeeId{get;set;}
        public string Name{get;set;}
    } 
    
        
    //ADO.NET CODES
    
        using System.Data;
        using System.Data.SqlClient;
        using System.Configuration;
        
        
        string cs = ConfigurationManager.ConnectionString["DBCS"].ConnectionStrings;
        using(SqlConnection con = ne SqlConnection(cs))
        {
           List<Employee> employee = new List<Employee>();
           SqlCommand cmd = new SqlCommand("select * from Employee",con);
           cmd.commandType = CommandType.Text;
           con.Open();
           SqlReader rdr = cmd.ExecuteReader();
           while(rdr.Read())
           {
              Employee emp = new Employee();
              emp.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
              emp.Name = rdr["Name"].ToString();
              
              employee.Add(emp);
           }
        }
