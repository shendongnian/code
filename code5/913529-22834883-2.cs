	public Dictionary<string, Dictionary<string, object>> GetEmployees()
	{
		try
		{
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NSConstr"].ToString());
			con.Open();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "SELECT *  FROM Contact e ";
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.SelectCommand.Connection = con;
			da.Fill(ds);
			con.Close();
			return DatatableToDictionary(ds.Tables[0]);
		}
		catch (Exception ex)
		{
			// Here you are returning a string, the method signature is Dictionary<string, Dictionary<string, object>>
			return errmsg(ex);
		}
	}
