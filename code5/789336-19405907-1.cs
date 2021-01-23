     Guid AgentGUID = Guid.Parse(AgentUID);
                   
     var AgentQuery = from a in db.Agents
                      join u in db.UserLogins on a.AgentUID equals u.UserUID into j
                      from u in j.DefaultIfEmpty()
                      where a.AgentUID == AgentGUID
                      select new { a.AgentUID, a.Name, Login = (u == null ? String.Empty : u.Login), UserUID = ( u == null ? Guid.Empty : u.UserUID), Type = (u == null ? -1 : u.Type) };
                                     
    foreach (var result in AgentQuery)
    {
        txtName.Text = result.Name;
        txtUsername.Text = result.Name;
    
        if (!string.IsNullOrEmpty(result.Login.ToString()))
        {
            chkEnableLogin.Checked = true;
            txtUsername.Text = result.Login;
            txtUsername.ReadOnly = true;
            ddlType.SelectedValue = result.Type.ToString();
            ViewState.Add("UserUID", result.UserUID);
        }
    }
