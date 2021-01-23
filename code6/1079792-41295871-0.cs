    string select = @"Select * From tblUsers Where Username = @Username and Password = @Password and PositionInTheCompany = @Privilege";
            using (con)
            {
                con.Open();
                using (cmd = new SqlCommand(select, con))
                {
                    cmd.Parameters.AddWithValue("@Username", txtLoginUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtLoginPassword.Text);
                    cmd.Parameters.AddWithValue("@Privilege", cmbLoginUsertype.Text);
                    using (read = cmd.ExecuteReader())
                    {
                        if (read.HasRows)
                        {
                            // you can also use the else if statements here for the user privileges
                            read.Read();
                            this.Hide()
                            dashboard.Show();
                            
                            txtLoginPassword.Text = "";
                            txtLoginUsername.Text = "";
                            cmbLoginUsertype.Text = "";
                        }
                        else
                        {
                            lblLoginMessage.Show();
                            lblLoginMessage.Text = "Access Denied!";
                            txtLoginPassword.Text = "";
                            txtLoginUsername.Text = "";
                            cmbLoginUsertype.Text = "";
                        }
                    }
                }
            }
