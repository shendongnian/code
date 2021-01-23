     public int Login(String Username, String Password)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from tbl_Staff where Username=@Username and Password=@Password", conn);
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    conn.Close();
                    if (dt.Rows.Count > 0)
                    {
                        string role = dt.Rows[0]["Roles"].ToString();
    
                        if (role.Equals("User"))
                        {
                            UserPanelFrm frm = new UserPanelFrm();
                            frm.ShowDialog();
                            this.Close();
                            return 1;
                        }
                        else if (role.Equals("Admin"))
                        {
                            FrmUserRole fur = new FrmUserRole();
                            fur.ShowDialog();
                            this.Close();
                            return 1;
                        }
                    }
    
                    return 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            private void btnLogin_Click(object sender, EventArgs e)
            {
                try
                {
                    int result = uc.Login(txtUserName.Text, txtPassword.Text);
                    if (result == 0)
                    {
                        MessageBox.Show("INVALID USERNAME OR PASSWORD");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
