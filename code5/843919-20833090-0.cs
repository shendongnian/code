    private void checkedListBoxSignIn_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (_updatingList) return; //if it is already doing it, don't do it again
        int userIndex = listBoxSignIn.SelectedIndex;
        try {
            _updatingList = true;
            UpdateUserList();
        } finally {
            _updatingList = false;
        }
        listBoxSignIn.SelectedIndex = userIndex;
    }
    
    private void UpdateUserList()
    {
        listBoxSignIn.Items.Clear();
    
        foreach (User u in _userList)
        {
            listBoxSignIn.Items.Add(u.Name);
        }
    }
    private void listBoxSignIn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updatingCheckList) return; //if it is already doing it, don't do it again
        int index = listBoxSignIn.SelectedIndex;
        try {
            _updatingCheckList = true;
            UpdateCheckListBox(index);
        finally { _updatingCheckList = false; }
    }
    
    private void UpdateCheckListBox(int index)
    {
        checkedListBoxSignIn.Items.Clear();
        foreach (Item i in _userList.Items)
        {
            checkedListBoxKartSignIn.Items.Add(i, i.status);
        }
    }
