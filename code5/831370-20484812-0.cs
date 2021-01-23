    if(dr.Read())
    {
                    if (this.CompareStrings(dr["SCSID"].ToString(), txtUser.Text) &&
                        this.CompareStrings(dr["SCSPass"].ToString(), txtPass.Text) &&
                        this.CompareStrings(dr["isAdmin"].ToString(), isAdmin))
                    {
                        MessageBox.Show("Hello " +txtUser.Text , "Admin" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                        _Adminform.Show();
                        this.Hide();
                    }
                    else if (this.CompareStrings(dr["SCSID"].ToString(), txtUser.Text) &&
                        this.CompareStrings(dr["SCSPass"].ToString(), txtPass.Text) &&
                        this.CompareStrings(dr["isAdmin"].ToString(), isNotAdmin))
                    {
                        MessageBox.Show("Welcome " + txtUser.Text , "User");
                        _userform.Show();
                        this.Hide();
                    }
    }
    else
    {
     MessageBox.Show("Wrong ID/Pass");
    }
