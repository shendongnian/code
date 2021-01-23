	public void grid()
	{
		var colourTable = new DataTable();
		colourTable.Columns.Add("Value", typeof(string));
		var colours = Request.QueryString["vaL1"].Split(',');
		for (int i = 0; i < colours.Length; i++)
		{
			var newRow = colourTable.NewRow();
			newRow[0] = colours[i];
			colourTable.Rows.Add(newRow);
		}
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
