    var cb = new SqlConnectionStringBuilder { DataSource = @".\Sqlexpress", InitialCatalog = "Medallion_OData_Tests_CustomersContext251990930203", IntegratedSecurity = true };
    using (var c = new SqlConnection(cb.ConnectionString))
    {
    	c.Open();	
    	
    	var cmd = c.CreateCommand();
    	cmd.CommandText = "SELECT CAST(1 AS tinyint)";
    	var reader = cmd.ExecuteReader();
    	reader.Read();
    	reader.GetByte(0).Dump();
    }
