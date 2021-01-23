    	private LoadGridView()
		{
			MyGridView.DataSource = GetMyData();
			MyGridView.DataBind();
		}
	
		private DataTable GetMyData()
		{
			DataTable result = new DataTable();
			SqlConnection con = new SqlConnection(SQLConn);
			SqlCommand cmd = new SqlCommand("[MyStoreProcedure]", con);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				con.Open();
				//Define parameters here
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(result);
			}
			catch (Exception ex)
			{
				//trap for errors
			}
			finally
			{
				con.Close();
				con.Dispose();
				cmd.Dispose();
			}
			return result;
		}
