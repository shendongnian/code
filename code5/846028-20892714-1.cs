    Dictionary<int, UserModel> users = new Dictionary<int, UserModel>();
    void AddItemToList(UserModel model)
    {
        if(users.ContainsKey(model.Id)) return; // avoid duplicates
    
        var listViewItem = new ListViewItem();
    
        listViewItem.Text = model.SSN;
        listViewItem.SubItems.Add(model.FirstName);
        listViewItem.SubItems.Add(model.LastName);
        
        listView.Items.Add(listViewItem);
    }
