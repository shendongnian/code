    private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "" || txtPassword.Text == "")
                {
                    lblError.Visible = true;
                    lblError.Text = "*Enter UserName and Password";
                    //MessageBox.Show(" Enter UserName and Password .");
                    return;
                }
                else
                {
                    
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MegaPixelBizConn"].ConnectionString))
                    {
                    
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM login_info WHERE userName = @Username AND password = @Password", con))
	                    {
                            // If these two lines don't work, replace "Username" and "Password" with "@Username"/"@Password"
                            cmd.Parameters.Add(new SqlParameter("Username", txtUserName.Text);
                            cmd.Parameters.Add(new SqlParameter("Password", txtPassword.Text);
                            SqlDataReader r = cmd.ExecuteReader();
                            if(r.HasRows())
                            {
                                // this assumes that there is only one user/password and no two users with same UID and PWORD
                                this.Hide();
                                Home hm = new Home();
                                hm.Show();
                            }
                            else
                            {
                                lblError.Text = "*Not Registered User or Invalid Name/Password";
                                //MessageBox.Show("Not Registered User or Invalid Name/Password");
                                txtPassword.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
