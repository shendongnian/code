    public EmployeeDepartment InsertEmployeeAndDepartment(params dynamic[] employee)
    {         
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();       
        filteredEmployees.EmployeeRecords = serializer.Deserialize<List<EmployeeRecords >>(employee);           
    }
