    if(Request.QueryString["ValuesFromUser"]!=null)
    {
        ValuesFromUser_ = Request["ValuesFromUser"];
    }
    
    var values = ValuesFromUser_.Split(",");
    
    using(var adapter = new SqlDataAdapter("Checkforuserinput", Connection))
    {
    	adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    	adapter.SelectCommand.Parameters.AddWithValue("@arg", values.ToSqlArray());
    	adapter.Fill(dtle);
    }
