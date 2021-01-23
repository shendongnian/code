    using (SqlConnection con = povezava) 
    {
    using (SqlCommand command = con.CreateCommand()) 
	{
        command.CommandText = tb_koda.Text;
        command.Connection = con;
        con.Open();
        using (SqlDataAdapter adapter = new SqlDataAdapter(command)) 
		{
			DataSet ds = new DataSet();
			da.Fill(ds);
			yourDataGrid.DataSource = ds.Tables[0];
			yourDataGrid.DataBind();
		}
		con.Close();
    }
    }
