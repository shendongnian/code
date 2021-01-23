	var qstr = "SELECT * FROM Products";
	var parms = new Dictionary<string, object>();
	if (!string.IsNullOrEmpty(session))
	{
		qstr += " WHERE CategoryID = @category";
		parms["category"] = session;
	}
	using (var cmd = connection.CreateCommand())
	{
		cmd.CommandType  = CommandType.Text;
		cmd.CommandText = qstr;
		foreach (var parm in parms)
			cmd.Parameters.AddWithValue("@" + parm.Key, parm.Value);
		using (var reader = cmd.ExecuteReader())
		{
			//....
		}	
	}
