                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT (*) FROM tblLogin WHERE Username= '" + txtUser.Text + "' AND Password= '" + txtPass.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    new frmDashboard().Show();
    
                }
                else
                {
                    lblNotify.Show();
                    lblNotify.Text = "Login Unsuccessful";
                    txtUser.Text = "";
                    txtPass.Text = "";
                }
            }
    
            private void frmLogin_Load(object sender, EventArgs e)
            {
                lblNotify.Hide();
            }
