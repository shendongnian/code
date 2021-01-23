    		try
			{
				using (var conn = new SqlConnection((ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString)))
				{
					conn.Open();
					
    #if DOUBLE_CHECK
					string CheckUser = "select count(*) from UserData where Username = @Username";
					SqlCommand com2 = new SqlCommand(CheckUser, conn);
					com2.Parameters.AddWithValue("@Username", UsernameTextBox.Text);
					if ((int)com2.ExecuteScalar() > 0)
					{
						Response.Write("User already exists");
						return;
					}
    #endif					
					string InsertQuerry = "insert into UserData (Username,Email,Password,Country) values (@Username,@Email,@Password,@Country)";
					SqlCommand com = new SqlCommand(InsertQuerry, conn);
					com.Parameters.AddWithValue("@Username", UsernameTextBox.Text);
					com.Parameters.AddWithValue("@Email", EmailTextBox.Text);
					com.Parameters.AddWithValue("@Password", PasswordTextBox.Text);
					com.Parameters.AddWithValue("@Country", CountryDropDownList.SelectedItem.ToString());
					com.ExecuteNonQuery();
					Response.Redirect("Manager.aspx");
				}
			}
			catch (SqlException se)
			{
				if (se.Errors.OfType<SqlError>().Any(e => e.Number == 2627))
				{
					Response.Write("User already exists");
				}
				else
				{
					Response.Write(se.ToString());					
				}
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
			}
