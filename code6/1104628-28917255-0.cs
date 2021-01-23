    protected void UserListView_ItemCommand(object sender, ListViewCommandEventArgs e)
      {
        if (String.Equals(e.CommandName, "AddRole"))
        {
         
          ListViewDataItem dataItem = (ListViewDataItem)e.Item;
          // this will gives you Row for your list items
        }
    }
