	//Assuming that your id column is first column and name is second column
	//get value of id and name
	int mId = Convert.ToInt32(GridView2.SelectedRow.Cells[0].Text);
	string mName = GridView2.SelectedRow.Cells[1].Text;
	string connectionStrng = "your connection string";
	string insertSql = "INSERT INTO Machining_Master (M_ID, M_NAME) VALUES (@mId, @mName)";
	using (SqlConnection conn = new SqlConnection(connectionStrng))
	{
		using (SqlCommand cmd = new SqlCommand(insertSql, conn))
		{
			try
			{
				cmd.Parameters.Add(new SqlParameter("mId", mId));
				cmd.Parameters.Add(new SqlParameter("mName", mName));
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			finally
			{
				//Close connection
				conn.Close();
			}
		}
	}
