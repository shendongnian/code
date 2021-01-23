    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO UserInfo(Login, Password, UserType) VALUES(@Login,@Password,@Type)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Login", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", TextBox2.Text + ".123");
                    cmd.Parameters.AddWithValue("@Type", DropDownList1.SelectedValue);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
 
