	public void grid()
	{
		string sql = "SELECT * FROM lady_clock WHERE Color IN (SELECT Value FROM @Colours)"
		DataSet ds3 = new DataSet();
		using (var adapter = new SqlDataAdapter(sql, con))
		{
			var parameter = new SqlParameter("@Colours", SqlDbType.Structured);
			parameter.Value = colourTable;
			parameter.TypeName = "dbo.StringList";
			adapter.Parameters.Add(parameter);
			con.Open();
			da1.Fill(ds3);
		} 
		if (ds3.Tables[0].Rows.Count > 0)
		{
			GridView1.DataSource = ds3;
			GridView1.DataBind();
		}
		else
		{
		}
	}
