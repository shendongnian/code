    public object ValidateUser(string UserName, string Password)
    {
        object retVal= null;
        string Result = String.Empty;
        Employees clsEmployee = new Employees();
        Customer clsCustomer = new Customer();
        // get the data
        Result = command.Parameters["@Result"].Value.ToString();
        if (Result == "Employee")
        {
            while (dr.Read())
            {
                clsEmployee.EmployeeId = (int)dr["EmployeeId"];
                clsEmployee.EmployeeName = (string)dr["EmployeeName"];
                clsEmployee.DepartmentName = (string)dr["DepartmentName"];
                clsEmployee.RoleName = (string)dr["RoleName"];
            }
            retVal=clsEmployee;
        }
       if (Result == "Customer")
        {
            while (dr.Read())
            {
                clsCustomer.CustomerId = (int)dr["CustomerId"];
                clsCustomer.CustomerName = (string)dr["CustomerName"];
                clsCustomer.CustomerEmail = (string)dr["CustomerEmail"];
                clsCustomer.CustomerMobile = (string)dr["CustomerMobile"];
            }
            retVal=clsCustomer;
        }
         retVal=Result;
         return retVal;
        }
 
