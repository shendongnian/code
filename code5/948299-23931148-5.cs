    DataTable dataTable = new DataTable("SampleDataType");
    
    // We create column names as per the type in DB 
    
    dataTable.Columns.Add("TestName", typeof(string)); 
    dataTable.Columns.Add("Value", typeof(Int32)); 
    
    // And fill in some values 
    
    dataTable.Rows.Add("Metal", 99); 
    dataTable.Rows.Add("HG", null);
    ...
    SqlParameter parameter = new SqlParameter(); 
    
    // The parameter for the SP must be of SqlDbType.Structured 
    
    parameter.ParameterName="@Test"; 
    parameter.SqlDbType = System.Data.SqlDbType.Structured; 
    parameter.Value = dataTable; 
    
    command.Parameters.Add(parameter); 
