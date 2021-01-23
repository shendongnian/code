    using (var sqlConnection = new SqlConnection("Data Source={yourdbserver};Initial Catalog=StudentsEnrolment;Integrated Security=True"))
    {
    	using (var command = new SqlCommand("select * from students"))
    	{
    		command.Connection = sqlConnection;
    		try
    		{
    			sqlConnection.Open();
    			var dataAdapter = new SqlDataAdapter(command);
    			DataTable table = new DataTable();
    			
    			dataAdapter.Fill(0, 10, table);
    			table.TableName = "Students";
    
    			table.Columns.Add(new DataColumn("TestingCollection", typeof(List<string>)));
    
    			var testingstring = new List<string>() { "String 1", "string 2", "string 3" };
    			foreach(DataRow datarow in table.Rows)
    			{
    				datarow.SetField("TestingCollection", testingstring);
    			}
    			var xmlWriter = new StringWriter();
    			table.WriteXml(xmlWriter);
    			Console.WriteLine(xmlWriter);
    		}
    		finally
    		{
    			sqlConnection.Close();
    		}
    	}
    }
