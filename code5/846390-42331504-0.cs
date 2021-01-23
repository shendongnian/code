    public ObjectResult<int> Insert_Department(string department)
    {
        var departmentParameter = new ObjectParameter("department", department);
  
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int>("insert_department", departmentParameter);
    }
