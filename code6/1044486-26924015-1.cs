	public void Get_Contact_Info()
	{
		using (var connection = new SqlConnection(roperties.Settings.Default.ConnectionString))
		{
			connection.Open();
			
			var SQL = "SELECT * FROM Customer_Contacts WHERE Contact_ID = @contact_Id";
			
			var sqlCommand = new SqlCommand(SQL, connection);
			sqlCommand.Parameters.AddWithValue("@Contact_Id", contact_Id);
			using (var sqlDataReader = sqlCommand.ExecuteReader())
			{
				while (sqlDataReader.Read())
				{
					contact_Id = sqlDataReader["Contact_ID"].ToString();
					
					TextBoxName.Text = sqlDataReader["Contact_Name"].ToString();
					//etc ...
				}
			}
		}
	}
