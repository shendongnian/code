    DataLayer DB {get; set;}
    protected void Page_Load(object sender, EventArgs e)
    {
        DB = new DataLayer("connectionstring");
    }
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        SystemUser user = new SystemUser()
        {
            Id = Session["ColumnID"].ToString(),
            FirstName = txt_firstname.Text
        }
        DB.UpdateUser(user);
    }
