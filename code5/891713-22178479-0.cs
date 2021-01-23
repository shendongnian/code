		public string Log(int userResult)
		{
			string result = "result saved";
			
			using (var conn = new SqlConnection("Data Source=XXXX;InitialCatalog=XXXX;Integrated Security=True"))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.CommandText = "dbo.setCalculatorResult";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					cmd.Parameters.AddWithValue("RESULT", userResult);
					if (conn.State != ConnectionState.Open)
						conn.Open();
					int rowCount = cmd.ExecuteNonQuery();
					if (rowCount == 0)
						result = "there was an error";
				}
			}
			return result;
		}
