    protected void outerRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
    	{
    		Repeater innerRepeater = e.Item.FindControl("innerRepeater") as Repeater;
    
    		String name = ((DataRowView)e.Item.DataItem)[0].ToString();
    
    		DataTable dt = GetSurname(name);
    		innerRepeater.DataSource = dt;//here isn't su
    		innerRepeater.DataBind();
    	}
    }
    
    private DataTable GetSurname(String name)
    {
    	using (SqlConnection myConnection = new SqlConnection(@"Data Source=(LocalDb)\v11.0; Database = TSQL2012"))
    	{
    		SqlDataAdapter da = new SqlDataAdapter("Select Surname from Person WHERE Name = @name", myConnection);
    		da.SelectCommand.Parameters.AddWithValue("@name", name);
    
    		DataTable dt = new DataTable();
    		da.Fill(dt);
    		return dt;
    	}
    }
        
