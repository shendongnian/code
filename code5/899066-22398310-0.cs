    public DataTable FillDataGrid(string sql)
		{
			var conn = new SqlConnection("Your connectionString");
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataAdapter sda = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable("Employee");
			sda.Fill(dt);
			return dt;
		}
