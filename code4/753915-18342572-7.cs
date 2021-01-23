    protected void Page_Load(object sender, EventArgs e)
    {
        SetButtonsEnabledDisabled(IsAdmin(userType));
    }
    private bool IsAdmin(int userTypeId)
    {
        return userTypeId == (int)UserType.Admin;
    }
    private void SetButtonsEnabledDisabled(bool isEnabled)
    {
        ButtonAdd.Enabled = isEnabled;
        ButtonEdit.Enabled = isEnabled;
        ButtonDelete.Enabled = isEnabled;
    }
