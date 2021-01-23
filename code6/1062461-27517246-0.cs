    private void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable result = uc.Login(txtUserName.Text, txtPassword.Text);
            if (result.Rows.Count == 1)
            {
                this.Hide();
                
                string role = result.Rows[0]["Role"].ToString();
         
                switch (role)
                {
                    case "User": 
                        UserPanelFrm frm = new UserPanelFrm();
                        frm.ShowDialog();
                        this.Close();
                        break;
                    case "Admin":
                        //Show a different form
                        FrmUserRole fur = new FrmUserRole();
                        fur.ShowDialog();
                        this.Close();
                        break;
                }
            }
            else
            {
            MessageBox.Show("INVALID USERNAME OR PASSWORD");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
