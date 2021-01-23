		private void AddCountry(string country, string id)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				string sql = string.Format("INSERT INTO Country (Id, Country) VALUES ('{0}', '{1}')", id, country);
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.ExecuteNonQuery();
				}
			}
		}
		private bool Exists(string country, string id)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				string sql = "SELECT Count(*) FROM Country WHERE Country='" + country + "'";
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					int count = (int)cmd.ExecuteScalar();
					return count >= 1;
				}
			}
		}
		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (Exists(txtcountry.Text, txtid.Text))
				{
					Response.Write("<script>alert('Country Already Exist!!!!')</script>");
				}
				else
				{
                    AddCountry(txtcountry.Text, txtid.Text);
					Response.Write("<script>alert('Country Added Succesfully')</script>");
				}
			}
			catch (Exception ex)
			{
				Label1.Text = ex.Message;
			}			
		}
