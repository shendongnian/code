    string[] rolesarr = Roles.GetAllRoles();
    DataTable dTable = new DataTable();
    dTable.Columns.Add("Select", typeof(bool));
    dTable.Columns.Add("Username", typeof(string));
    Array.ForEach(rolesarr, r => dTable.Columns.Add(r, typeof(bool)));
    foreach (MembershipUser u in Membership.GetAllUsers())
    {
        DataRow dRow = dTable.NewRow();
        dRow[0] = false;
        dRow[1] = u.UserName;
        string[] roles = Roles.GetRolesForUser(u.UserName);
    
        for (int i = 0; i < rolesarr.Length; i++)
        {
            for (int j = 0; j < roles.Length; j++)
            {
                if (rolesarr[i] == roles[j])
                {
                    dRow[i + 2] = true;
                    break;
                }
            }
        }
        dTable.Rows.Add(dRow);
    }
    GridView1.DataSource = dTable;
    GridView1.DataBind(); 
