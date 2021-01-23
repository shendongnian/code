    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridviewData();
        }
    }
    protected void BindGridviewData()
    {
        DataTable dTable = new DataTable();
        dTable.Columns.Add("col0", typeof(string));
        dTable.Columns.Add("col1", typeof(bool));
        dTable.Columns.Add("col2", typeof(bool));
        dTable.Columns.Add("col3", typeof(bool));
        foreach (MembershipUser u in Membership.GetAllUsers())
        {
            DataRow dRow = dTable.NewRow();
            dRow[0] = u.UserName;
            string[] roles = Roles.GetRolesForUser(u.UserName);
            dRow[1] = roles.Contains("Admin") ? true : false;
            dRow[2] = roles.Contains("DPAO User") ? true : false;
            dRow[3] = roles.Contains("GeneralUser") ? true : false;
            dTable.Rows.Add(dRow);
        }
        GridView1.DataSource = dTable;
        GridView1.DataBind();
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkChild");
            if (chk.Checked)
            {
                Label username = (Label)row.FindControl("Label1");
                Membership.DeleteUser(username.Text);
                BindGridviewData();
            }
        }
    }
