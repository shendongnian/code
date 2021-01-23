    protected void cmdUpdateRole_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            List<string> roles=new List<string>();
            Label username = (Label)row.FindControl("Label1");
            CheckBox chkAdmin = (CheckBox)row.FindControl("chkAdmin");
            CheckBox chkUser = (CheckBox)row.FindControl("chkUser");
            CheckBox chkgen = (CheckBox)row.FindControl("chkgen");
            if (chkAdmin.Checked)
                roles.Add("Admin");  
            if (chkUser.Checked)
                roles.Add("DPAO User");
            if (chkgen.Checked)
                roles.Add("GeneralUser");
            if (Roles.GetRolesForUser(username.Text).Length > 0)
            {
                Roles.RemoveUserFromRoles(username.Text, Roles.GetRolesForUser(username.Text));
            }
            if (roles.Count > 0)
            {
                Roles.AddUserToRoles(username.Text, roles.ToArray());
            }
            BindGridviewData();
        }
    }
