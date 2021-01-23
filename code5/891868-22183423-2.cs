    DataTable dt = new DataTable("IntegerList");
    dt.Columns.Add("value", typeof(int));
    
    foreach(var i in cartList) {
    	dt.Rows.Add(i);
    }
    
    using(var command = Connection.CreateCommand()) {
    	command.CommandText = "Query";
    	
    	var param = new SqlParameter("@integers", SqlDbType.Structured);
    	param.TypeName = "dbo.IntegerList";
    	param.Value = dt;
    	command.Parameters.Add(param);
    	
    	Connection.Open();
    	command.ExecuteNonQuery();
    }
