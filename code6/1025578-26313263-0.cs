    	public void combobox_SelectedIndexChanged()
		{
			string selectedCountry = "country"; //build actual connection string as you do now.
			string connectionString = string.Format("Data Source={0};Initial Catalog=Detrack;Integrated Security=True;", selectedCountry);
			var sqlCon = new SqlConnection(connectionString);
			using (sqlCon)
			{
				// Disable some controls
				try
				{
					sqlCon.Open();
				}
				catch (SqlException ex)
				{
					MessageBox.Show(ex.Message);
					// Disable "OK"/"Next" button
					return;
				}
				finally
				{
					///Enable controls
				}
				
				sqlCon.Close();
				// "OK"/"Next" button
			}
		}
