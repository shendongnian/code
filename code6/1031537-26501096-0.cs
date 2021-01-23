    BindingList<xml.UserDescriptor> _users;
    public NewForm(BindingList<xml.UserDescriptor> users)
    {
        _users = users;
    }
    private void btnAddUser_Click(object sender, EventArgs e)
    {
       _users.Add(new xml.UserDescriptor(){...});
    }
