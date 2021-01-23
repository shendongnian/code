        string strSelect2 = "SELECT ROLEID FROM LOGIN_DETAILS WHERE EMAIL_ID=@EMAIL_ID";
        cmd.CommandText = strSelect2;
        username = new SqlParameter("@EMAIL_ID", SqlDbType.NVarChar, 36);
        username.Value = tbx_lpc_username.Text.Trim().ToString();
        cmd.Parameters.Add(username);
    
      
        int roleId = (Int32)cmd.ExecuteScalar();
        if (roleId == 2) //USER
            {
                Session.Add("usnm", tbx_lpc_username.Text);
                Response.Redirect("~/ADMIN_PAGES/LPC_ADM_HomePage.aspx");
            }
            else if (roleId == 1) // ADMIN
            {
                Session.Add("usnm", tbx_lpc_username.Text);
                Response.Redirect("~/ADMIN_PAGES/LPC_ADM_SettingsPage.aspx");
            }
