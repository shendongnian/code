    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonAdd.Enabled = userType = (int)UserType.Add;
        ButtonEdit.Enabled = userType = (int)UserType.Edit;
        ButtonDelete.Enabled = userType = (int)UserType.Delete;
    }
